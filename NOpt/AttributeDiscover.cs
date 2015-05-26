using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace NOpt
{
    internal static class AttributeDiscover
    {
        private static readonly Regex validOptionName = new Regex(@"^_\w+|[\w-[0-9_-]]\w*$", RegexOptions.Compiled);

        /// <summary>
        /// Extract option class memebers via reflaction into dictoinary
        /// </summary>
        /// <param name="optionType">Option class or struct type</param>
        /// <param name="hasVerb">return true, if verb is present</param>
        /// <returns>
        /// Dictionary with keys: string for shortnames, longnames and verb, int for unbounded value index
        /// </returns>
        public static Dictionary<object, FieldInfo> Discover(Type optionType, out bool hasVerb)
        {
            hasVerb = false;

            var attributes = new Dictionary<object, FieldInfo>();

            foreach (FieldInfo field in optionType.GetFields())
            {
                var valueAttributes = field.GetCustomAttributes<ValueAttribute>();
                var optionsAttributes = field.GetCustomAttributes<OptionAttribute>();
                var verbAttributes = field.GetCustomAttributes<VerbAttribute>();
                int attrCount =
                    (valueAttributes.Any() ? 1 : 0) +
                    (optionsAttributes.Any() ? 1 : 0) +
                    (verbAttributes.Any() ? 1 : 0);

                if (attrCount > 1)
                    throw new ArgumentException(
                        "ValueAttribute, OptionAttribute and VerbAttribute are mutually exclusive and can not be used in the same class field", field.Name);

                if (valueAttributes.Any())
                {
                    foreach(var attr in valueAttributes)
                    {
                        if (attributes.ContainsKey(attr.Index))
                            throw new ArgumentException(
                                $"Two class fields marked as ValueAttribute with same index: '{attributes[attr.Index].Name}' and {field.Name}");

                        attributes[attr.Index] = field;
                    }
                }

                if(optionsAttributes.Where(a => a.MutuallyExclusive != null).Count() > 1)
                    throw new ArgumentException(
                                $"Field {field.Name} marked with {nameof(OptionAttribute.MutuallyExclusive)} attribute more than one time");

                if (optionsAttributes.Any())
                {
                    foreach(var attr in optionsAttributes)
                    {
                        if (attr.ShortName != null)
                        {
                            if (!char.IsLetter(attr.ShortName.Value))
                                throw new ArgumentException("Short name must be letter", field.Name);

                            string strShortName = attr.ShortName.Value.ToString();

                            if (attributes.ContainsKey(strShortName))
                                throw new ArgumentException(
                                    $"Two class fields marked as OptionAttribute with same short name: '{attributes[attr.ShortName.Value].Name}' and {field.Name}");

                            attributes[strShortName] = field;
                        }
                        if (attr.LongName != null)
                        {
                            if (!validOptionName.IsMatch(attr.LongName))
                                throw new ArgumentException("Long name invalid", field.Name);

                            if (attributes.ContainsKey(attr.LongName))
                                throw new ArgumentException(
                                    $"Two class fields marked with same long name: '{attributes[attr.LongName].Name}' and {field.Name}");

                            attributes[attr.LongName] = field;
                        }
                    }
                }

                if (verbAttributes.Any())
                {
                    foreach(var attr in verbAttributes)
                    {
                        if (attributes.ContainsKey(attr.Name))
                            throw new ArgumentException(
                                $"Two class fields marked with same long name: '{attributes[attr.Name].Name}' and {field.Name}");

                        attributes[attr.Name] = field;
                        hasVerb = true;
                    }
                }
            }

            return attributes;
        }
    }
}
