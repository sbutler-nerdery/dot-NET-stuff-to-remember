using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Miniprofiler.CodeFirst.Extensions
{
    internal static class EFExtensions
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