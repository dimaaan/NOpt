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
        // TODO document exceptions list
        public static T Parse<T>(string[] args) where T : new()
        {
            T options;
            string errorMessage;
            bool res = TryParse<T>(args, out options, out errorMessage);

            if(!res)
                throw new FormatException(errorMessage);

            return options;
        }

        public static bool TryParse<T>(string[] args, out T options, out string errorMessage) where T: new()
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            options = new T();
            errorMessage = Parse(args, options);

            return errorMessage == null;
        }


        private static string Parse(IEnumerable<string> args, object opt)
        {
            string errorMessage;
            bool hasVerb;
            Dictionary<object, FieldInfo> attributes = AttributeDiscover.Discover(opt.GetType(), out hasVerb);
            string firstArg = args.FirstOrDefault();

            // check first argument is a verb
            if (hasVerb && firstArg != null && attributes.ContainsKey(firstArg))
            {
                FieldInfo field = attributes[firstArg];
                object verbInstance = Activator.CreateInstance(field.FieldType); // TODO handle errors

                errorMessage = Parse(args.Skip(1), verbInstance);

                if (errorMessage == null)
                    field.SetValue(opt, verbInstance);
            }
            else
            {
                errorMessage = TokenizeUnixStyle(args, opt, attributes);
            }

            return errorMessage;
        }


        /// <returns>null if success, otherwise error message</returns>
        private static string TokenizeUnixStyle<T>(IEnumerable<string> args, T opt, Dictionary<object, FieldInfo> attributes)
        {
            // TODO --a=b syntax

            string errorMessage = null;
            var e = args.GetEnumerator();
            int valuesCount = 0;

            while (e.MoveNext())
            {
                if (e.Current == null)
                    continue;

                if (e.Current.StartsWith("--")) // in case "program --file file.txt" or "program --file=file.txt"
                {
                    if (e.Current.Length < 3)
                    {
                        errorMessage = "Error: dash without name. Use '--long-name'";
                        break;
                    }

                    string name = e.Current.Substring(2);
                    string attachedValue = null;
                    int equalPos = name.IndexOf('=');

                    if(equalPos == name.Length - 1)
                    {
                        errorMessage = $"Error: invalid syntax {e.Current}";
                        break;
                    }

                    if(equalPos != -1)
                    {
                        attachedValue = equalPos != -1 ? name.Substring(equalPos + 1) : null;
                        name = name.Substring(0, equalPos);
                    }

                    errorMessage = setOption(opt, attributes, name, attachedValue, e);
                    if (errorMessage != null)
                        break;
                }
                else if (e.Current.StartsWith("-")) // in case "program -f file.txt"
                {
                    if (e.Current.Length == 2) // in case "program -f"
                    {
                        char name = e.Current[1];

                        errorMessage = setOption(opt, attributes, name.ToString(), null, e);
                        if (errorMessage != null)
                            break;
                    }
                    else if (e.Current.Length > 2) // in case "program -abc"
                    {
                        for (int i = 1; i < e.Current.Length; i++)
                        {
                            char name = e.Current[i];
                            errorMessage = setOption(opt, attributes, name.ToString(), null, null);
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

            return errorMessage;
        }


        /// <param name="attachedValue">In case of --file=r.txt 'r.txt' is attached value</param>
        /// <param name="e">Enumerator to get value if need and no attachedValue exist. Null if option do not have a value (ex. -abc)</param>
        /// <returns></returns>
        private static string setOption(object opt, Dictionary<object, FieldInfo> attributes, string name, string attachedValue, IEnumerator<string> e)
        {
            string errorMessage;
            FieldInfo fieldInfo;

            if (!attributes.TryGetValue(name, out fieldInfo))
            {
                errorMessage = $"Invalid option: {name}";
            }
            else
            {
                if (fieldInfo.FieldType == typeof(bool))
                {
                    if(attachedValue != null)
                    {
                        errorMessage = $"Option {name} should not have a value. Passed value: {attachedValue}";
                    }
                    else
                    {
                        errorMessage = AssignToField(opt, fieldInfo, true);
                    }
                }
                else
                {
                    if (attachedValue != null || e != null && e.MoveNext())
                    {
                        string value = attachedValue != null ? attachedValue : e.Current;

                        if (String.IsNullOrEmpty(value))
                            errorMessage = $"Value of {name} is empty string";
                        else
                            errorMessage = AssignToField(opt, fieldInfo, value);
                    }
                    else
                    {
                        errorMessage = $"Option {name} should have a value";
                    }
                }
            }

            return errorMessage;
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
