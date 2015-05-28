using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace NOpt
{
    // TODO compare complexity of code with "commandline"

    // TODO document enums. See Enum.Parse help

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


        private static string Parse(string[] args, object opt)
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

                errorMessage = Parse(args.Skip(1).ToArray(), verbInstance);

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
        private static string TokenizeUnixStyle<T>(string[] args, T opt, Dictionary<object, FieldInfo> attributes)
        {
            string errorMessage = null;
            int valuesCount = 0;
            var mutuallyExclusiveGroups = new List<string>();

            for (int i = 0; i < args.Length; i++)
            {
                string currArg = args[i];

                if (currArg == null)
                    continue;

                if (currArg.StartsWith("--")) // in case "program --file file.txt" or "program --file=file.txt"
                {
                    if (currArg.Length < 3)
                    {
                        errorMessage = "Error: dash without name. Use '--long-name'";
                        break;
                    }

                    string name = currArg.Substring(2);
                    string attachedValue = null;
                    int equalPos = name.IndexOf('=');

                    if(equalPos == name.Length - 1)
                    {
                        errorMessage = $"Error: invalid syntax {currArg}";
                        break;
                    }

                    if(equalPos != -1)
                    {
                        attachedValue = equalPos != -1 ? name.Substring(equalPos + 1) : null;
                        name = name.Substring(0, equalPos);
                    }

                    errorMessage = setOption(opt, attributes, name, attachedValue, args, ref i, mutuallyExclusiveGroups);
                    if (errorMessage != null)
                        break;
                }
                else if (currArg.StartsWith("-")) // in case "program -f file.txt"
                {
                    if (currArg.Length == 2) // in case "program -f"
                    {
                        char name = currArg[1];

                        errorMessage = setOption(opt, attributes, name.ToString(), null, args, ref i, mutuallyExclusiveGroups);
                        if (errorMessage != null)
                            break;
                    }
                    else if (currArg.Length > 2) // in case "program -abc"
                    {
                        for (int j = 1; j < currArg.Length; j++)
                        {
                            char name = currArg[j];
                            errorMessage = setOption(opt, attributes, name.ToString(), null, null, ref i, mutuallyExclusiveGroups);
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
                    errorMessage = setValue(opt, attributes, valuesCount++, currArg);

                    if (errorMessage != null)
                        break;
                }
            }

            return errorMessage;
        }


        /// <param name="attachedValue">In case of --file=r.txt 'r.txt' is attached value</param>
        /// <param name="e">Enumerator to get value if need and no attachedValue exist. Null if option do not have a value (ex. -abc)</param>
        /// <returns></returns>
        private static string setOption(object opt, Dictionary<object, FieldInfo> attributes, string name, string attachedValue, 
            string[] args, ref int i, List<string> mutuallyExclusiveGroups)
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
                    if (attachedValue != null || args != null && ++i < args.Length)
                    {
                        string value = attachedValue != null ? attachedValue : args[i];

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

                // check that no mutually exclusive options are used
                var optionAttr = fieldInfo.GetCustomAttributes<OptionAttribute>().Where(a => a.MutuallyExclusive != null).FirstOrDefault();
                if(optionAttr != null)
                {
                    if(mutuallyExclusiveGroups.Contains(optionAttr.MutuallyExclusive))
                    {
                        var mutNames = attributes.Values
                            .SelectMany(a => a.GetCustomAttributes<OptionAttribute>())
                            .Where(o => o.MutuallyExclusive == optionAttr.MutuallyExclusive)
                            .SelectMany(a => new object[] { a.ShortName, a.LongName })
                            .Where(a => a != null)
                            .Distinct();
                        errorMessage = $"Options {string.Join(", ", mutNames)} are mutually exclusive";
                    }
                    else
                    {
                        mutuallyExclusiveGroups.Add(optionAttr.MutuallyExclusive);
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
