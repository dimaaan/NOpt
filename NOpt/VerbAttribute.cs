using System;

namespace NOpt
{
    /// <summary>
    /// A command to execute.
    /// Verb must be first argument.
    /// <example>
    /// "git commit". Commit is a verb.
    /// Other examples: 
    /// program save -f file
    /// program load -f file
    /// "save" and "load" is a verbs
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, 
        AllowMultiple = false, 
        Inherited = true)]
    public sealed class VerbAttribute : Attribute
    {
        public VerbAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}