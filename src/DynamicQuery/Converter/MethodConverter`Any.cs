using System.Linq.Dynamic.Extensions;
using System.Reflection;
using Newtonsoft.Json;

namespace System.Linq.Dynamic
{
    internal class MethodConverterByAny : IMethodConverterProvider
    {
        public bool Match(DynamicQueryParam queryParam, Type propertyType)
        {
            return queryParam.Operator == QueryOperation.Any;
        }

        public void Converter(DynamicQueryParam queryParam, Type propertyType, DynamicQueryKeyValueCollection collection)
        {
            if (!propertyType.IsConstructedGenericType)
                throw new LinqDynamicException("只有泛型类型能够使用此方法");
            var type = propertyType.GetGenericArguments().FirstOrDefault();
            if (type == null)
                throw new LinqDynamicException("只有泛型类型能够使用此方法");
            var group = JsonConvert.DeserializeObject<DynamicQueryParamGroup>((queryParam.Value ?? "").ToString());
            if ((group == null) || (group.ChildGroups == null))
                return;
            group.CheckDynamicQueryParamGroup();
            collection.Builder.Append($"{queryParam.Field}.Any(");
            ConverterHelper.ConverterQueryParamGroup(type, group, collection);
            collection.Builder.Append($")");
        }
    }
}