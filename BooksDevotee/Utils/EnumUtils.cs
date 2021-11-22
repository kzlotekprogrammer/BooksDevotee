using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BooksDevotee.Utils
{
    public class EnumUtils
    {
        public static string GetDisplayValue<T>(T value) where T : struct, Enum
        {
            FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());

            DisplayAttribute[] descriptionAttributes = 
                fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null) 
                return string.Empty;

            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
        }
    }
}
