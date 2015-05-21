using System;
using System.Linq;
using System.Reflection;

namespace NOpt
{
    public static class NOpt
    {
        // TODO exceptions list
        public static T Parse<T>(string[] args) where T: new()
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            // TODO first check for a verbs

            T opt = new T();
            Type optType = opt.GetType();
            var members = from m in optType.GetMembers()
                                 where m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property
                                 select m;

            foreach (MemberInfo m in members)
            {
                var nOptAttrs = from customAttr in m.CustomAttributes
                               let attrType = customAttr.AttributeType
                               where
                               attrType == typeof(ValueAttribute) ||
                               attrType == typeof(OptionAttribute) ||
                               attrType == typeof(VerbAttribute)
                               select customAttr;

                if (nOptAttrs.Count() > 1)
                    throw new ArgumentException("ValueAttribute, OptionAttribute and VerbAttribute are mutually exclusive and can not be used in the same class member", m.Name);

                CustomAttributeData attr = nOptAttrs.FirstOrDefault();

                if(attr != null)
                {
                    Type memberType = m.MemberType == MemberTypes.Field ? ((FieldInfo)m).FieldType : ((PropertyInfo)m).PropertyType;

                    if (attr.AttributeType == typeof(ValueAttribute))
                    {
                        if (memberType != typeof(string))
                            throw new ArgumentException("ValueAttribute can be used only with strings", m.Name);

                        // TODO need tokenizer to continue
                    }
                    else if(attr.AttributeType == typeof(OptionAttribute))
                    {

                    }
                    else // VerbAttribute
                    {

                    }
                }
            }

            return opt;
        }
    }
}
