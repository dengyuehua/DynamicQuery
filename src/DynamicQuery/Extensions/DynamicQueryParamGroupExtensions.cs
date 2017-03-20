using JetBrains.Annotations;

namespace System.Linq.Dynamic.Extensions
{
    internal static class DynamicQueryParamGroupExtensions
    {
        public static void CheckDynamicQueryParamGroup([NotNull] this DynamicQueryParamGroup group)
        {
            if (group.Params.Any() && group.ChildGroups.Any())
                throw new LinqDynamicException("DynamicQueryParamGroup不能同时添加Params和Group");
        }
    }
}
