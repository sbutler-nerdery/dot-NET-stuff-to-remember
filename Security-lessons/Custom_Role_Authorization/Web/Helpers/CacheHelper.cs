using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace Web.Helpers
{
    public class CacheHelper
    {
        private static ObjectCache Cache { get { return MemoryCache.Default; } }

        /// <summary>
        /// Get a cached object
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object Get(string key)
        {
            return Cache[key];
        }

        /// <summary>
        /// Set a cached value to the specified key
        /// </summary>
        /// <param name="key">The key in the cache</param>
        /// <param name="data">The object to cache</param>
        /// <param name="cacheTime">The time for it to remain cached (in minutes)</param>
        public static void Set(string key, object data, int cacheTime)
        {
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);

            Cache.Add(new CacheItem(key, data), policy);
        }

        /// <summary>
        /// Find out of the cache contains the specifed key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsSet(string key)
        {
            return (Cache[key] != null);
        }

        /// <summary>
        /// Remove a key from the cache
        /// </summary>
        /// <param name="key"></param>
        public static void Invalidate(string key)
        {
            Cache.Remove(key);
        }

    }
}