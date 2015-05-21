using System;

namespace NOpt
{
    /// <summary>
    /// Value that are not bound to named option. Can be bound only to strings.
    /// </summary>
    /// <example>
    /// program.exe file1 file2
    /// <code>
    /// class Options {
    /// 
    ///     [Value(0)]
    ///     public string opt1; // will be "file1"
    /// 
    ///     [Value(1)]
    ///     public string opt2; // will be "file2"
    /// 
    ///     [Value(2)]
    ///     public string opt3; // will be null
    /// 
    ///     [Value(3, DefaultValue="default")]
    ///     public string opt4; // will be "default"
    /// }
    /// </code>
    /// </example>
    /// <remarks>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, 
        AllowMultiple = false, 
        Inherited = true)]
    public sealed class ValueAttribute : Attribute
    {
        /// <param name="index">Position in the command line. Starts from zero</param>
        public ValueAttribute(int index)
        {
            Index = index;
        }

        /// <summary>
        /// Position in the command line. Starts from zero
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Sets if no value supplied from command line
        /// </summary>
        public object DefaultValue { get; set; }
    }
}
