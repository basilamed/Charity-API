using Charity_API.Data.DTOs;
using System.Linq.Expressions;

namespace Charity_API.SortingAndPaging
{
    public static class QueryExtension
    {
        //za sortiranje
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, DonationQuery donationQuery, Dictionary<string, Expression<Func<T, object>>> sortCol)
        {
            if (string.IsNullOrEmpty(donationQuery.SortBy) || !sortCol.ContainsKey(donationQuery.SortBy))
            {
                return query;
            }

            bool isSortAscending = donationQuery.IsSortAscending ?? false;

            if (isSortAscending)
            {
                query = query.OrderBy(sortCol[donationQuery.SortBy]);
            }
            else
            {
                query = query.OrderByDescending(sortCol[donationQuery.SortBy]);
            }

            return query;
        }



        //paginacija
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, DonationQuery donationQuery)
        {
            int page = donationQuery.Page ?? 1;
            int pageSize = donationQuery.PageSize ?? 10;

            if (page <= 0)
            {
                page = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 10;
            }

            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
