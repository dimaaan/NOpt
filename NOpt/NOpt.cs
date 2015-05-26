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
            Dictionary<object, FieldInfo> attributes = NOptAttributes.Discover(opt.GetType(), out hasVerb);

            return TokenizeUnixStyle(args, opt, attributes, hasVerb);
        }

        

        /// <returns>null if success, otherwise error message</returns>
        private static string TokenizeUnixStyle<T>(IEnumerable<string> args, T opt, Dictionary<object, FieldInfo> attributes, bool hasVerb)
        {
            // TODO --a=b syntax

            string errorMessage = null;

            string firstArg = args.FirstOrDefault();

            if (hasVerb && firstArg != null && attributes.ContainsKey(firstArg)) // check first argument is a verb
            {
                FieldInfo field = attributes[firstArg];
                Type fieldType = field.FieldType;
                object verbInstance = Activator.CreateInstance(fieldType); // TODO handle errors

                errorMessage = Parse(args.Skip(1), verbInstance);
                if (errorMessage != null)
                    return errorMessage;

                field.SetValue(opt, verbInstance);
            }
            else // no verbs
            {
                var e = args.GetEnumerator();
                int valuesCount = 0;

                while (e.MoveNext())
                {
                    if (e.Current == null)
                        continue;

                    if (e.Current.StartsWith("--")) // in case "program --file file.txt"
                    {
                        if (e.Current.Length < 3)
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
                        if (e.Current.Length == 2) // in case "program -f"
                        {
                            char name = e.Current[1];
                            string val = e.MoveNext() ? e.Current : null;

                            errorMessage = setOption(opt, attributes, name, val);
                            if (errorMessage != null)
                                break;
                        }
                        else if (e.Current.Length > 2) // in case "program -abc"
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
                        errorMessage = setValue(opt, attributes, valuesCount++, e.Current);

                        if (errorMessage != null)
                            break;
                    }
                }
            }

            return errorMessage;
        }

        private static string setOption(object opt, Dictionary<object, FieldInfo> attributes, string longName, string value)
        {
            FieldInfo fieldInfo;

            if (!attributes.TryGetValue(longName, out fieldInfo))
                return $"Invalid option: --{value}";

            if(value == null)
            {
                if (fieldInfo.FieldType != typeof(bool))
                    return $"Option --{longName} should have a value";

                return AssignToField(opt, fieldInfo, true);
            }
            else
            {
                if (String.IsNullOrEmpty(value))
                    return $"Value for {fieldInfo.Name} is empty string";

                return AssignToField(opt, fieldInfo, value);
            }
        }

        private static string setOption(object opt, Dictionary<object, FieldInfo> attributes, char shortName, string value)
        {
            FieldInfo fieldInfo;

            if (!attributes.TryGetValue(shortName, out fieldInfo))
                return $"Invalid option: -{value}";

            if(value == null)
            {
                if (fieldInfo.FieldType != typeof(bool))
                    return $"Option -{shortName} should have a value";

                return AssignToField(opt, fieldInfo, true);
            }
            else
            {
                if (String.IsNullOrEmpty(value))
                    return $"Value for {fieldInfo.Name} is empty string";

                return AssignToField(opt, fieldInfo, value);
            }
        }

        private static string setValue(object opt, Dictionary<object, FieldInfo> attributes, int index, string value)
        {
            FieldInfo fieldInfo;

            if (!attributes.TryGetValue(index, out fieldInfo))
                return $"Invalid argument: {value}";

            if (String.IsNullOrEmpty(value))
                return $"Value for {fieldInfo.Name} is null or empty string";

            return AssignToField(opt, fieldInfo, value);
        }

        private static string AssignToField(object opt, FieldInfo f, object value)
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
    }
}
