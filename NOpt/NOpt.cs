using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NOpt
{
    // TODO compare complexity of code with "commandline"

    public static class NOpt
    {
        // TODO document exceptions list
        public static T Parse<T>(string[] args) where T : new()
        {
            T options = new T();

            Parse(args, options);

            return options;
        }

        public static bool TryParse<T>(string[] args, out T options, out string errorMessage) where T: new()
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            options = new T();
            try
            {
                Parse(args, options);
                errorMessage = null;
            }
            catch(FormatException e)
            {
                errorMessage = e.Message;
            }

            return errorMessage == null;
        }


        private static void Parse(string[] args, object opt)
        {
            bool hasVerb;
            Dictionary<object, PropertyInfo> attributes = AttributeDiscover.Discover(opt.GetType(), out hasVerb);
            string firstArg = args.FirstOrDefault();

            // check first argument is a verb
            if (hasVerb && firstArg != null && attributes.ContainsKey(firstArg))
            {
                PropertyInfo prop = attributes[firstArg];
                object verbInstance = Activator.CreateInstance(prop.PropertyType); // TODO handle errors

                Parse(args.Skip(1).ToArray(), verbInstance);
                prop.SetValue(opt, verbInstance);
            }
            else
            {
                TokenizeUnixStyle(args, opt, attributes);
            }
        }


        /// <returns>null if success, otherwise error message</returns>
        private static void TokenizeUnixStyle<T>(string[] args, T opt, Dictionary<object, PropertyInfo> attributes)
        {
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
                        throw new FormatException("Error: dash without name. Use '--long-name'");

                    string name = currArg.Substring(2);
                    string attachedValue = null;
                    int equalPos = name.IndexOf('=');

                    if(equalPos == name.Length - 1)
                        throw new FormatException($"Error: invalid syntax {currArg}");

                    if(equalPos != -1)
                    {
                        attachedValue = equalPos != -1 ? name.Substring(equalPos + 1) : null;
                        name = name.Substring(0, equalPos);
                    }

                    setOption(opt, attributes, name, attachedValue, args, ref i, mutuallyExclusiveGroups, '-');
                }
                else if (currArg.StartsWith("-")) // in case "program -f file.txt"
                {
                    if (currArg.Length == 2) // in case "program -f"
                    {
                        char name = currArg[1];
                        setOption(opt, attributes, name.ToString(), null, args, ref i, mutuallyExclusiveGroups, '-');
                    }
                    else if (currArg.Length > 2) // in case "program -abc"
                    {
                        for (int j = 1; j < currArg.Length; j++)
                        {
                            char name = currArg[j];
                            setOption(opt, attributes, name.ToString(), null, null, ref i, mutuallyExclusiveGroups, '-');
                        }
                    }
                    else // in case "program -"
                    {
                        throw new FormatException("Error: dash without name. Use '-s'");
                    }
                }
                else // in case "program file.txt"
                {
                    setValue(opt, attributes, valuesCount++, currArg);
                }
            }
        }


        /// <param name="attachedValue">In case of --file=r.txt 'r.txt' is attached value</param>
        /// <param name="e">Enumerator to get value if need and no attachedValue exist. Null if option do not have a value (ex. -abc)</param>
        /// <returns></returns>
        private static void setOption(object opt, Dictionary<object, PropertyInfo> attributes, string name, string attachedValue, 
            string[] args, ref int i, List<string> mutuallyExclusiveGroups, char optionStartSymbol)
        {
            PropertyInfo propInfo;

            if (!attributes.TryGetValue(name, out propInfo))
                throw new FormatException($"Invalid option: {name}");

            if (propInfo.PropertyType == typeof(bool))
            {
                if(attachedValue != null)
                    throw new FormatException($"Option {name} should not have a value. Passed value: {attachedValue}");

                AssignToProp(opt, propInfo, true);
            }
            else if(propInfo.PropertyType == typeof(string[]))
            {
                if (attachedValue != null)
                    throw new FormatException($"Bad syntax near option {name}");

                var values = new List<string>();

                for(int j = i + 1; j < args.Length; j++)
                {
                    if(args[j][0] != optionStartSymbol)
                    {
                        values.Add(args[j]);
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                if(values.Count != 0)
                    AssignToProp(opt, propInfo, values.ToArray());
            }
            else
            {
                if(attachedValue == null && (args == null || args.Length < ++i))
                    throw new FormatException($"Option {name} should have a value");

                string value = attachedValue != null ? attachedValue : args[i];

                if (String.IsNullOrEmpty(value))
                    throw new FormatException($"Value of {name} is empty string");
                    
                AssignToProp(opt, propInfo, value);
            }

            // check that no mutually exclusive options are used
            var optionAttr = propInfo.GetCustomAttributes<OptionAttribute>().Where(a => a.MutuallyExclusive != null).FirstOrDefault();
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
                    throw new FormatException($"Options {string.Join(", ", mutNames)} are mutually exclusive");
                }
                else
                {
                    mutuallyExclusiveGroups.Add(optionAttr.MutuallyExclusive);
                }
            }
        }


        private static void setValue(object opt, Dictionary<object, PropertyInfo> attributes, int index, string value)
        {
            PropertyInfo propInfo;

            if (!attributes.TryGetValue(index, out propInfo))
                throw new FormatException($"Invalid argument: {value}");

            if (String.IsNullOrEmpty(value))
                throw new FormatException($"Value for {propInfo.Name} is null or empty string");

            AssignToProp(opt, propInfo, value);
        }


        private static void AssignToProp(object opt, PropertyInfo f, object value)
        {
            if(f.PropertyType.IsEnum)
            {
                object enumValue;

                try
                {
                    string strValue = (string)value;
                    strValue = strValue.Replace('-', '_'); // so we could map "no-file" to enum { NO_FILE }
                    enumValue = Enum.Parse(f.PropertyType, strValue, true);
                }
                catch(Exception e)
                {
                    throw new FormatException($"Bad argument: '{value}'. Expected values: {String.Join(",", Enum.GetNames(f.PropertyType))}", e);
                }

                f.SetValue(opt, enumValue);
            }
            else
            {
                f.SetValue(opt, value);
            }
        }
    }
}
