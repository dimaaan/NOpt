using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace NOpt
{
    internal static class NOptAttributes
    {
        private static readonly Regex validOptionName = new Regex(@"^_\w+|[\w-[0-9_-]]\w*$", RegexOptions.Compiled);

        /// <summary>
        /// Extract option class memebers via reflaction into dictoinary
        /// </summary>
        /// <param name="optionType">Option class or struct type</param>
        /// <param name="hasVerb">return true, if verb is present</param>
        /// <returns>
        /// Dictionary with keys: char for shortname, string for longname and verb, int for unbounded value index
        /// </returns>
        public static Dictionary<object, MemberInfo> Discover(Type optionType, out bool hasVerb)
        {
            hasVerb = false;

            Dictionary<object, MemberInfo> attributes = new Dictionary<object, MemberInfo>();

            foreach (MemberInfo member in optionType.GetMembers())
            {
                var valueAttributes = member.GetCustomAttributes<ValueAttribute>();
                var optionsAttributes = member.GetCustomAttributes<OptionAttribute>();
                var verbAttributes = member.GetCustomAttributes<VerbAttribute>();
                int attrCount =
                    (valueAttributes.Any() ? 1 : 0) +
                    (optionsAttributes.Any() ? 1 : 0) +
                    (verbAttributes.Any() ? 1 : 0);

                if (attrCount > 1)
                    throw new ArgumentException(
                        "ValueAttribute, OptionAttribute and VerbAttribute are mutually exclusive and can not be used in the same class member", member.Name);

                if (valueAttributes.Any())
                {
                    foreach(var attr in valueAttributes)
                    {
                        if (attributes.ContainsKey(attr.Index))
                            throw new ArgumentException(
                                $"Two class members marked as ValueAttribute with same index: '{attributes[attr.Index].Name}' and {member.Name}");

                        attributes[attr.Index] = member;
                    }
                }

                if (optionsAttributes.Any())
                {
                    foreach(var attr in optionsAttributes)
                    {
                        if (attr.ShortName != null)
                        {
                            if (!char.IsLetter(attr.ShortName.Value))
                                throw new ArgumentException("Short name must be letter", member.Name);

                            if (attributes.ContainsKey(attr.ShortName.Value))
                                throw new ArgumentException(
                                    $"Two class members marked as OptionAttribute with same short name: '{attributes[attr.ShortName.Value].Name}' and {member.Name}");

                            attributes[attr.ShortName.Value] = member;
                        }
                        if (attr.LongName != null)
                        {
                            if (!validOptionName.IsMatch(attr.LongName))
                                throw new ArgumentException("Long name invalid", member.Name);

                            if (attributes.ContainsKey(attr.LongName))
                                throw new ArgumentException(
                                    $"Two class members marked with same long name: '{attributes[attr.LongName].Name}' and {member.Name}");

                            attributes[attr.LongName] = member;
                        }
                    }
                }

                if (verbAttributes.Any())
                {
                    foreach(var attr in verbAttributes)
                    {
                        if (attributes.ContainsKey(attr.Name))
                            throw new ArgumentException(
                                $"Two class members marked with same long name: '{attributes[attr.Name].Name}' and {member.Name}");

                        attributes[attr.Name] = member;
                        hasVerb = true;
                    }
                }
            }

            return attributes;
        }
    }
}
