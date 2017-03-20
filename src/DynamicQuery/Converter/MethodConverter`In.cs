using System.Collections.Generic;
using System.Linq;

namespace System.Linq.Dynamic
{
    internal class MethodConverterByIn : IMethodConverterProvider
    {
        public bool Match(DynamicQueryParam queryParam, Type propertyType)
        {
            return queryParam.Operator == QueryOperation.In;
        }

        public void Converter(DynamicQueryParam queryParam, Type propertyType, DynamicQueryKeyValueCollection collection)
        {
            if (string.IsNullOrWhiteSpace(queryParam.Value?.ToString()))
                throw new ArgumentException("IN操作必须提供Value.");
            var arr = queryParam.Value.ToString()
                .Trim()
                .Split(',')
                .Where(i => !string.IsNullOrWhiteSpace(i))
                .Select(i => TypeConverterHelper.ChangeType(i, propertyType)).ToList();
            object valObj = null;

            #region 处理类型

            if (propertyType == typeof(string))
            {
                var strList = new List<string>();
                strList.AddRange(arr.Select(i => i.ToString()));
                valObj = strList;
            }
            if (propertyType == typeof(int))
            {
                var strList = new List<int>();
                strList.AddRange(arr.Select(i => int.Parse(i.ToString())));
                valObj = strList;
            }

            if (propertyType == typeof(int?))
            {
                var strList = new List<int?>();
                foreach (var o in arr)
                {
                    strList.Add(int.Parse(o.ToString()));
                }
                valObj = strList;
            }


            if (propertyType == typeof(decimal))
            {
                var strList = new List<decimal>();
                strList.AddRange(arr.Select(i => decimal.Parse(i.ToString())));
                valObj = strList;
            }

            if (propertyType == typeof(decimal?))
            {
                var strList = new List<decimal?>();
                foreach (var o in arr)
                {
                    strList.Add(int.Parse(o.ToString()));
                }
                valObj = strList;
            }

            if (propertyType == typeof(ulong))
            {
                var strList = new List<ulong>();
                strList.AddRange(arr.Select(i => ulong.Parse(i.ToString())));
                valObj = strList;
            }
            if (propertyType == typeof(ulong?))
            {
                var strList = new List<ulong?>();
                foreach (var o in arr)
                {
                    strList.Add(ulong.Parse(o.ToString()));
                }
                valObj = strList;
            }

            if (propertyType == typeof(long))
            {
                var strList = new List<long>();
                strList.AddRange(arr.Select(i => long.Parse(i.ToString())));
                valObj = strList;
            }
            if (propertyType == typeof(long?))
            {
                var strList = new List<long?>();
                foreach (var o in arr)
                {
                    strList.Add(long.Parse(o.ToString()));
                }
                valObj = strList;
            }

            if (propertyType == typeof(uint))
            {
                var strList = new List<uint>();
                strList.AddRange(arr.Select(i => uint.Parse(i.ToString())));
                valObj = strList;
            }

            if (propertyType == typeof(uint?))
            {
                var strList = new List<ulong?>();
                foreach (var o in arr)
                {
                    strList.Add(uint.Parse(o.ToString()));
                }
                valObj = strList;
            }

            if (propertyType == typeof(double))
            {
                var strList = new List<double>();
                strList.AddRange(arr.Select(i => double.Parse(i.ToString())));
                valObj = strList;
            }

            if (propertyType == typeof(float))
            {
                var strList = new List<float>();
                strList.AddRange(arr.Select(i => float.Parse(i.ToString())));
                valObj = strList;
            }

            if (propertyType == typeof(float?))
            {
                var strList = new List<float?>();
                foreach (var o in arr)
                {
                    strList.Add(float.Parse(o.ToString()));
                }
                valObj = strList;
            }

            if (propertyType == typeof(byte))
            {
                var strList = new List<byte>();
                strList.AddRange(arr.Select(i => byte.Parse(i.ToString())));
                valObj = strList;
            }

            if (propertyType == typeof(byte?))
            {
                var strList = new List<byte?>();
                foreach (var o in arr)
                {
                    strList.Add(byte.Parse(o.ToString()));
                }
                valObj = strList;
            }



            if (propertyType == typeof(double?))
            {
                var strList = new List<double?>();
                foreach (var o in arr)
                {
                    strList.Add(double.Parse(o.ToString()));
                }
                valObj = strList;
            }

            if (valObj == null)
            {
                valObj = arr;
            }

            #endregion

            if (!arr.Any())
                throw new ArgumentException("IN操作必须提供Value.");
            collection.Builder.Append($" @{collection.Ids++}.Contains({queryParam.Field}) ");
            collection.Values.Add(valObj);
        }
    }
}