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
        /// <typeparam name="T">Option class</typeparam>
        /// <param name="opt">Option instance</param>
        /// <param name="hasVerb">return true, if verb option is present</param>
        /// <returns>
        /// Dictionary with keys: char for shortname, string for longname and verb, int for unbounded value index
        /// </returns>
        public static Dictionary<object, MemberInfo> Discover<T>(T opt, out bool hasVerb)
        {
            hasVerb = false;

            Type optType = opt.GetType();
            Dictionary<object, MemberInfo> attributes = new Dictionary<object, MemberInfo>();

            foreach (MemberInfo member in optType.GetMembers())
            {
                ValueAttribute valueAttribute = member.GetCustomAttribute<ValueAttribute>();
                OptionAttribute optionsAttribute = member.GetCustomAttribute<OptionAttribute>();
                VerbAttribute verbAttribute = member.GetCustomAttribute<VerbAttribute>();
                int attrCount =
                    (valueAttribute != null ? 1 : 0) +
                    (optionsAttribute != null ? 1 : 0) +
                    (verbAttribute != null ? 1 : 0);

                if (attrCount > 1)
                    throw new ArgumentException(
                        "ValueAttribute, OptionAttribute and VerbAttribute are mutually exclusive and can not be used in the same class member", member.Name);

                if (valueAttribute != null)
                {
                    if (attributes.ContainsKey(valueAttribute.Index))
                        throw new ArgumentException(
                            $"Two class members marked as ValueAttribute with same index: '{attributes[valueAttribute.Index].Name}' and {member.Name}");

                    attributes[valueAttribute.Index] = member;
                }

                if (optionsAttribute != null)
                {
                    if (optionsAttribute.ShortName != null)
                    {
                        if (!char.IsLetter(optionsAttribute.ShortName.Value))
                            throw new ArgumentException("Short name must be letter", member.Name);

                        if (attributes.ContainsKey(optionsAttribute.ShortName.Value))
                            throw new ArgumentException(
                                $"Two class members marked as OptionAttribute with same short name: '{attributes[optionsAttribute.ShortName.Value].Name}' and {member.Name}");

                        attributes[optionsAttribute.ShortName.Value] = member;
                    }
                    if (optionsAttribute.LongName != null)
                    {
                        if (!validOptionName.IsMatch(optionsAttribute.LongName))
                            throw new ArgumentException("Long name invalid", member.Name);

                        if (attributes.ContainsKey(optionsAttribute.LongName))
                            throw new ArgumentException(
                                $"Two class members marked with same long name: '{attributes[optionsAttribute.LongName].Name}' and {member.Name}");

                        attributes[optionsAttribute.LongName] = member;
                    }
                }

                if (verbAttribute != null)
                {
                    if (attributes.ContainsKey(verbAttribute.Name))
                        throw new ArgumentException(
                            $"Two class members marked with same long name: '{attributes[verbAttribute.Name].Name}' and {member.Name}");

                    attributes[verbAttribute.Name] = member;
                    hasVerb = true;
                    break;
                }
            }

            return attributes;
        }
    }
}
