using System;

namespace NOpt
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, 
        AllowMultiple = false, 
        Inherited = true)]
    public sealed class VerbAttribute : Attribute
    {

    }
}