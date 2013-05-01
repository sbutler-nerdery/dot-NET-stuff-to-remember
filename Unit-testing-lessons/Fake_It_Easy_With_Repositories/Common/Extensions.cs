using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    internal static class Extensions
    {
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable, params string[] includes) where T : class
        {
            if ((includes == null) || (includes.Length == 0))
                return queryable;

            return includes.Aggregate(queryable, (current, include) => current.Include(include));
        }
        public static IQueryable<T> IncludeAll<T, TProperty>(this IQueryable<T> queryable, params Expression<Func<T, TProperty>>[] includes) where T : class
        {
            if ((includes == null) || (includes.Length == 0))
                return queryable;

            return includes.Aggregate(queryable, (current, include) => current.Include(include));
        }
    }
}
