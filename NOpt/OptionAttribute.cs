﻿using System;

namespace NOpt
{
    /// <summary>
    /// Named option that can have a value.
    /// Option without values binds to boolean types.
    /// </summary>
    /// <example>
    /// program.exe -abc -f file1  --second-file file2
    /// <code>
    /// class Options {
    /// 
    ///     [Option('a')]
    ///     public string opt1; // will be null, because no value supplied
    /// 
    ///     [Option('b')]
    ///     public bool opt2; // will be true, because option exists in command line
    /// 
    ///     [Option('с')]
    ///     public string opt3 = "default"; // will be "default"
    /// 
    ///     [Option('d')]
    ///     public bool opt4; // will be false
    /// 
    ///     [Option('f')]
    ///     public string opt5; // will be "file1"
    /// 
    ///     [Option('s', LongName = "second-file")]
    ///     public string opt5; // will be "file2"
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = true)]
    public sealed class OptionAttribute : Attribute
    {
        public OptionAttribute(char shortName)
        {
            ShortName = shortName;
        }

        public OptionAttribute(string longName)
        {
            LongName = longName;
        }

        public OptionAttribute(char shortName, string longName)
        {
            ShortName = shortName;
            LongName = longName;
        }

        public char? ShortName { get; set; }

        public string LongName { get; set; }

        public string MutuallyExclusive { get; set; }
    }
}
