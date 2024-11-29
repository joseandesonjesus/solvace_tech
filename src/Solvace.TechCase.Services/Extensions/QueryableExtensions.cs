using Microsoft.EntityFrameworkCore;

namespace Solvace.TechCase.Services.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<(List<T> Items, int TotalCount)> PaginateAsync<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize)
        {
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
