using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace NOpt
{
    // TODO compare complexity of code with "commandline"

    public static class NOpt
    {
        private static readonly Regex validOptionName = new Regex(@"^_\w+|[\w-[0-9_-]]\w*$", RegexOptions.Compiled);

        // TODO exceptions list
        public static T Parse<T>(string[] args) where T: new()
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            T opt = new T();
            Dictionary<object, MemberInfo> attributes = DiscoverNOptAttributes(opt);

            TokenizeUnixStyle(args, opt, attributes);

            return opt;
        }

        /// <summary>
        /// Extract option class memebers via reflaction into dictoinary
        /// </summary>
        /// <typeparam name="T">Option class</typeparam>
        /// <param name="opt">Option instance</param>
        /// <returns>
        /// Dictionary with keys: char for shortname, string for longname, int for unbounded value index
        /// </returns>
        private static Dictionary<object, MemberInfo> DiscoverNOptAttributes<T>(T opt)
        {
            Type optType = opt.GetType();
            var members = from m in optType.GetMembers()
                          where m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property
                          select m;

            var attributes = new Dictionary<object, MemberInfo>();

            foreach (MemberInfo member in members)
            {
                var nOptAttrsData = from customAttr in member.CustomAttributes
                                let attrType = customAttr.AttributeType
                                where
                                attrType == typeof(ValueAttribute) ||
                                attrType == typeof(OptionAttribute) ||
                                attrType == typeof(VerbAttribute)
                                select customAttr;

                if (nOptAttrsData.Count() > 1)
                    throw new ArgumentException("ValueAttribute, OptionAttribute and VerbAttribute are mutually exclusive and can not be used in the same class member", member.Name);

                CustomAttributeData attrData = nOptAttrsData.FirstOrDefault();

                if (attrData != null)
                {
                    if (attrData.AttributeType == typeof(ValueAttribute))
                    {
                        int index = (int)attrData.ConstructorArguments[0].Value;

                        if (attributes.ContainsKey(index))
                            throw new ArgumentException(
                                $"Two class memebrs marked as ValueAttribute with same index: '{attributes[index].Name}' and {member.Name}");

                        attributes[index] = member;
                    }
                    else if (attrData.AttributeType == typeof(OptionAttribute))
                    {
                        if (attrData.ConstructorArguments[0].Value != null)
                        {
                            char shortName = (char)attrData.ConstructorArguments[0].Value;

                            if (!char.IsLetter(shortName))
                                throw new ArgumentException("Short name must be letter", member.Name);

                            attributes.Add(shortName, member);
                        }
                        else if (attrData.ConstructorArguments[1].Value != null)
                        {
                            string longName = (string)attrData.ConstructorArguments[1].Value;

                            if (!validOptionName.IsMatch(longName))
                                throw new ArgumentException("Long name invalid", member.Name);

                            attributes.Add(longName, member);
                        }
                        else
                        {
                            throw new ArgumentException("Short or long name requireq", member.Name);
                        }
                    }
                    else // VerbAttribute
                    {
                        // TODO recursive call
                    }
                }
            }

            return attributes;
        }

        /// <returns>null if success, otherwise error message</returns>
        private static string TokenizeUnixStyle<T>(IEnumerable<string> args, T opt, Dictionary<object, MemberInfo> attributes)
        {
            // TODO --a=b syntax

            string errorMessage = null;
            int valuesCount = 0;

            var e = args.GetEnumerator();
            while (e.MoveNext())
            {
                if (e.Current.StartsWith("--")) // in case "program --file file.txt"
                {
                    if(e.Current.Length < 3)
                    {
                        errorMessage = "Error: dash without name. Use '--long-name'";
                        break;
                    }

                    string name = e.Current.Substring(2);
                    string val = e.MoveNext() ? e.Current : null;

                    setOption(opt, attributes, name, val);
                }
                else if (e.Current.StartsWith("-")) // in case "program -f file.txt"
                {
                    if(e.Current.Length == 2) // in case "program -f"
                    {
                        char name = e.Current[1];
                        string val = e.MoveNext() ? e.Current : null;

                        setOption(opt, attributes, name, val);
                    }
                    else if(e.Current.Length > 2) // in case "program -abc"
                    {
                        char name;
                        for (int i = 1; i < e.Current.Length; i++)
                        {
                            name = e.Current[i];
                            setOption(opt, attributes, name, null);
                        }
                    }
                    else // in case "program -"
                    {
                        errorMessage = "Error: dash without name. Use '-s'";
                        break;
                    }
                }
                else // in case "program file.txt"
                {
                    errorMessage = setValue(opt, attributes, valuesCount++, e.Current);

                    if (errorMessage != null)
                        break;
                }
            }

            return errorMessage;
        }

        private static void setOption<T>(T opt, Dictionary<object, MemberInfo> attributes, string longName, string value)
        {
            throw new NotImplementedException("setOption long");
        }

        private static void setOption<T>(T opt, Dictionary<object, MemberInfo> attributes, char shortName, string value)
        {
            throw new NotImplementedException("setOption short");
        }

        private static string setValue<T>(T opt, Dictionary<object, MemberInfo> attributes, int index, string value)
        {
            MemberInfo memberInfo;

            if (!attributes.TryGetValue(index, out memberInfo))
                return $"Invalid argument: {value}";

            if (String.IsNullOrEmpty(value))
                return $"Value for {memberInfo.Name} is null or empty string";

            if (memberInfo is FieldInfo)
            {
                FieldInfo f = (FieldInfo)memberInfo;
                f.SetValue(opt, value);
            }
            else if(memberInfo is PropertyInfo)
            {
                PropertyInfo f = (PropertyInfo)memberInfo;
                f.SetValue(opt, value);
            }
            else
            {
                throw new ArgumentException("ValueAttribute should be appiled only to fields or properties", memberInfo.Name);
            }

            return null;
        }
    }
}
