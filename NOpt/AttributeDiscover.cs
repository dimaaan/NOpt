using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace NOpt
{
    internal static class AttributeDiscover
    {
        private static readonly Regex validOptionName = new Regex(@"^_\w+|[\w-[0-9_-]]\w*$");

        /// <summary>
        /// Extract option class members via reflection into dictionary
        /// </summary>
        /// <param name="optionType">Option class or structure type</param>
        /// <param name="hasVerb">return true, if verb is present</param>
        /// <returns>
        /// Dictionary with keys: string for short names, long names and verb, int for unbounded value index
        /// </returns>
        public static Dictionary<object, PropertyInfo> Discover(Type optionType, out bool hasVerb)
        {
            hasVerb = false;

            var attributes = new Dictionary<object, PropertyInfo>();

            foreach (PropertyInfo prop in optionType.GetTypeInfo().DeclaredProperties)
            {
                var valueAttributes = prop.GetCustomAttributes<ValueAttribute>();
                var optionsAttributes = prop.GetCustomAttributes<OptionAttribute>();
                var verbAttributes = prop.GetCustomAttributes<VerbAttribute>();
                int attrCount =
                    (valueAttributes.Any() ? 1 : 0) +
                    (optionsAttributes.Any() ? 1 : 0) +
                    (verbAttributes.Any() ? 1 : 0);

                if (attrCount > 1)
                    throw new ArgumentException(
                        "ValueAttribute, OptionAttribute and VerbAttribute are mutually exclusive and can not be used in the same class property", prop.Name);

                if (valueAttributes.Any())
                {
                    foreach(var attr in valueAttributes)
                    {
                        if (attributes.ContainsKey(attr.Index))
                            throw new ArgumentException(
                                $"Two class properties marked as ValueAttribute with same index: '{attributes[attr.Index].Name}' and {prop.Name}");

                        attributes[attr.Index] = prop;
                    }
                }

                if(optionsAttributes.Where(a => a.MutuallyExclusive != null).Count() > 1)
                    throw new ArgumentException(
                                $"Property {prop.Name} marked with {nameof(OptionAttribute.MutuallyExclusive)} attribute more than one time");

                if (optionsAttributes.Any())
                {
                    foreach(var attr in optionsAttributes)
                    {
                        if (attr.ShortName != null)
                        {
                            if (!char.IsLetter(attr.ShortName.Value))
                                throw new ArgumentException("Short name must be letter", prop.Name);

                            string strShortName = attr.ShortName.Value.ToString();

                            if (attributes.ContainsKey(strShortName))
                                throw new ArgumentException(
                                    $"Two class properties marked as OptionAttribute with same short name: '{attributes[attr.ShortName.Value].Name}' and {prop.Name}");

                            attributes[strShortName] = prop;
                        }
                        if (attr.LongName != null)
                        {
                            if (!validOptionName.IsMatch(attr.LongName))
                                throw new ArgumentException("Long name invalid", prop.Name);

                            if (attributes.ContainsKey(attr.LongName))
                                throw new ArgumentException(
                                    $"Two class properties marked with same long name: '{attributes[attr.LongName].Name}' and {prop.Name}");

                            attributes[attr.LongName] = prop;
                        }
                    }
                }

                if (verbAttributes.Any())
                {
                    foreach(var attr in verbAttributes)
                    {
                        if (attributes.ContainsKey(attr.Name))
                            throw new ArgumentException(
                                $"Two class properties marked with same long name: '{attributes[attr.Name].Name}' and {prop.Name}");

                        attributes[attr.Name] = prop;
                        hasVerb = true;
                    }
                }
            }

            return attributes;
        }
    }
}
