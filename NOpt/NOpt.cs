using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace NOpt
{
    // TODO compare complexity of code with "commandline"

    // TODO document enums. See Enum.Parse help

    // TODO mutual exclusive

    public static class NOpt
    {

        // TODO exceptions list
        public static T Parse<T>(string[] args) where T: new()
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            T opt = new T();

            Parse(args, opt);

            return opt;
        }

        private static string Parse(IEnumerable<string> args, object opt)
        {
            bool hasVerb;
            Dictionary<object, MemberInfo> attributes = NOptAttributes.Discover(opt.GetType(), out hasVerb);

            return TokenizeUnixStyle(args, opt, attributes, hasVerb);
        }

        

        /// <returns>null if success, otherwise error message</returns>
        private static string TokenizeUnixStyle<T>(IEnumerable<string> args, T opt, Dictionary<object, MemberInfo> attributes, bool hasVerb)
        {
            // TODO --a=b syntax

            string errorMessage = null;
            int valuesCount = 0, count = 0;

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

                        errorMessage = setOption(opt, attributes, name, val);
                        if (errorMessage != null)
                            break;
                    }
                    else if(e.Current.Length > 2) // in case "program -abc"
                    {
                        char name;
                        for (int i = 1; i < e.Current.Length; i++)
                        {
                            name = e.Current[i];
                            errorMessage = setOption(opt, attributes, name, null);
                            if (errorMessage != null)
                                break;
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
                    if(count == 0 && valuesCount == 0 && hasVerb && attributes.ContainsKey(e.Current)) // maybe this is a verb?
                    {
                        MemberInfo verbMember = attributes[e.Current];

                        if(verbMember is FieldInfo)
                        {
                            FieldInfo f = (FieldInfo)verbMember;
                            Type verbType = f.FieldType;
                            object verbInstance = Activator.CreateInstance(verbType); // TODO handle errors

                            errorMessage = Parse(args.Skip(1), verbInstance);
                            if (errorMessage != null)
                                break;
                            f.SetValue(opt, verbInstance);
                        }
                        else if(verbMember is PropertyInfo)
                        {
                            PropertyInfo p = (PropertyInfo)verbMember;
                            Type verbType = p.PropertyType;
                            object verbInstance = Activator.CreateInstance(verbType); // TODO handle errors

                            errorMessage = Parse(args.Skip(1), verbInstance);
                            if (errorMessage != null)
                                break;
                            p.SetValue(opt, verbInstance);
                        }
                        else
                        {
                            throw new ArgumentException("VerbAttribute should be appiled to fields and properties");
                        }
                    }
                    else // its a value
                    {
                        errorMessage = setValue(opt, attributes, valuesCount++, e.Current);

                        if (errorMessage != null)
                            break;
                    }
                }

                count++;
            }

            return errorMessage;
        }

        private static string setOption<T>(T opt, Dictionary<object, MemberInfo> attributes, string longName, string value)
        {
            MemberInfo memberInfo;

            if (!attributes.TryGetValue(longName, out memberInfo))
                return $"Invalid option: --{value}";

            if(value == null)
            {
                if (memberInfo is FieldInfo)
                {
                    FieldInfo f = (FieldInfo)memberInfo;

                    if (f.FieldType != typeof(bool))
                        return $"Option --{longName} should have a value";

                    return AssignValueTo(opt, f, true);
                }
                else if (memberInfo is PropertyInfo)
                {
                    PropertyInfo p = (PropertyInfo)memberInfo;

                    if (p.PropertyType != typeof(bool))
                        return $"Option --{longName} should have a value";

                    return AssignValueTo(opt, p, true);
                }
                else
                {
                    throw new ArgumentException("OptionAttribute should be appiled only to fields or properties", memberInfo.Name);
                }
            }
            else
            {
                if (String.IsNullOrEmpty(value))
                    return $"Value for {memberInfo.Name} is empty string";

                return AssignValueTo(opt, memberInfo, value);
            }
        }

        private static string setOption<T>(T opt, Dictionary<object, MemberInfo> attributes, char shortName, string value)
        {
            MemberInfo memberInfo;

            if (!attributes.TryGetValue(shortName, out memberInfo))
                return $"Invalid option: -{value}";

            if(value == null)
            {
                if(memberInfo is FieldInfo)
                {
                    FieldInfo f = (FieldInfo)memberInfo;

                    if (f.FieldType != typeof(bool))
                        return $"Option -{shortName} should have a value";

                    return AssignValueTo(opt, f, true);
                }
                else if(memberInfo is PropertyInfo)
                {
                    PropertyInfo p = (PropertyInfo)memberInfo;

                    if (p.PropertyType != typeof(bool))
                        return $"Option -{shortName} should have a value";

                    return AssignValueTo(opt, p, true);
                }
                else
                {
                    throw new ArgumentException("OptionAttribute should be appiled only to fields or properties", memberInfo.Name);
                }
            }
            else
            {
                if (String.IsNullOrEmpty(value))
                    return $"Value for {memberInfo.Name} is empty string";

                return AssignValueTo(opt, memberInfo, value);
            }
        }

        private static string setValue<T>(T opt, Dictionary<object, MemberInfo> attributes, int index, string value)
        {
            MemberInfo memberInfo;

            if (!attributes.TryGetValue(index, out memberInfo))
                return $"Invalid argument: {value}";

            if (String.IsNullOrEmpty(value))
                return $"Value for {memberInfo.Name} is null or empty string";

            return AssignValueTo(opt, memberInfo, value);
        }

        private static string AssignValueTo<T>(T opt, MemberInfo m, object value)
        {
            if(m is FieldInfo)
            {
                return AssignValueTo(opt, (FieldInfo)m, value);
            }
            else if (m is PropertyInfo)
            {
                return AssignValueTo(opt, (PropertyInfo)m, value);
            }
            else
            {
                throw new ArgumentException("NOpt attributes should be appiled only to fields or properties", m.Name);
            }
        }

        private static string AssignValueTo<T>(T opt, FieldInfo f, object value)
        {
            if(f.FieldType.IsEnum)
            {
                object enumValue;

                try
                {
                    enumValue = Enum.Parse(f.FieldType, (string) value, true);
                }
                catch(Exception)  {
                    return $"Bad argument: '{value}'. Expected values: {String.Join(",", Enum.GetNames(f.FieldType))}";
                }

                f.SetValue(opt, enumValue);
            }
            else
            {
                f.SetValue(opt, value);
            }

            return null;
        }

        private static string AssignValueTo<T>(T opt, PropertyInfo p, string value)
        {
            if (p.PropertyType.IsEnum)
            {
                object enumValue;

                try
                {
                    enumValue = Enum.Parse(p.PropertyType, value, true);
                }
                catch (Exception)
                {
                    return $"Bad argument: '{value}'. Expected values: {String.Join(",", Enum.GetNames(p.PropertyType))}";
                }

                p.SetValue(opt, enumValue);
            }
            else
            {
                p.SetValue(opt, value);
            }

            return null;
        }
    }
}
