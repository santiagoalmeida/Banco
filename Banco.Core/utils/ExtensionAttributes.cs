using System.Runtime.Serialization;

namespace Banco.Core.utils
{
    public static class ExtensionAttributes
    {
        public static string GetEnumAttrValue(this Enum @enum)
        {
            var attr =
                @enum.GetType().GetMember(@enum.ToString()).FirstOrDefault()?.
                    GetCustomAttributes(false).OfType<EnumMemberAttribute>().
                    FirstOrDefault();
            if (attr == null)
                return @enum.ToString();
            return attr.Value;
        }

        public static string GetEnumName<T>(this T @enum) where T : Enum
        {
            return Enum.GetName(typeof(T), @enum);
        }

        public static T ToEnum<T>(string str)
        {
            var enumType = typeof(T);
            return (T)Enum.Parse(typeof(T), str);
            //foreach (var name in Enum.GetNames(enumType))
            //{
            //    var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            //    if (enumMemberAttribute.Value == str) return (T)Enum.Parse(enumType, name);
            //}
            //return default(T);
        }
    }
}
