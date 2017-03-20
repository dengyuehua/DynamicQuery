using JetBrains.Annotations;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace System.Linq.Dynamic
{
    public static class DynamicQueryExtensions
    {
        public static async Task<PageResult> AutoQueryAsync<TEntity>([NotNull] this IQueryable<TEntity> source, [NotNull] DynamicQuery queryModel)
        {
            var entityType = typeof(TEntity);
            var converter = new QueryConverter(entityType, queryModel);
            var model = converter.Converter();
            return await source.AutoQueryAsync(model);
        }

        public static async Task<PageResult> AutoQueryAsync<TEntity>([NotNull] this IQueryable<TEntity> source, [NotNull] DynamicQueryModel dynamicQuery)
        {
            var s = source;
            if (!string.IsNullOrWhiteSpace(dynamicQuery.Where))
                s = source.Where(dynamicQuery.Where, dynamicQuery.WhereValue.ToArray());
            if (!string.IsNullOrWhiteSpace(dynamicQuery.Order))
                s = s.OrderBy(dynamicQuery.Order);
            if (!dynamicQuery.IsPager)
            {
                if (string.IsNullOrWhiteSpace(dynamicQuery.Select))
                    return new PageResult() { Rows = await s.ToListAsync() };
                return new PageResult() { Rows = source.Select(dynamicQuery.Select) };
            }

            var pageResult = new PageResult
            {
                Total = source.Count()
            };

            if (string.IsNullOrWhiteSpace(dynamicQuery.Select))
                pageResult.Rows = await s
                    .Skip(dynamicQuery.Skip < 0 ? 0 : dynamicQuery.Skip)
                    .Take(dynamicQuery.Take < 0 ? 10 : dynamicQuery.Take)
                    .ToListAsync();
            else
                pageResult.Rows = s.Select(dynamicQuery.Select)
                    .Skip(dynamicQuery.Skip < 0 ? 0 : dynamicQuery.Skip)
                    .Take(dynamicQuery.Take < 0 ? 10 : dynamicQuery.Take);
            return pageResult;
        }
    }
}
