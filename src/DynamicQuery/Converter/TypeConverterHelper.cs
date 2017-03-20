using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace System.Linq.Dynamic
{
    internal class TypeConverterHelper
    {
        public static object ChangeType(object objValue, Type conversionType)
        {
            object value = null;
            if (!conversionType.GetTypeInfo().IsGenericType)
            {
                value = conversionType.Name.Equals("Guid")
                    ? Guid.Parse(objValue.ToString())
                    : (conversionType.GetTypeInfo().IsEnum
                        ? Enum.Parse(conversionType, objValue.ToString())
                        : Convert.ChangeType(objValue, conversionType));
                //;
            }
            else
            {
                var genericTypeDefinition = conversionType.GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(Nullable<>))
                {
                    var converter = new NullableConverter(conversionType);
                    value = converter.ConvertFromString(objValue.ToString());
                }
            }
            return value;
        }
    }
}
