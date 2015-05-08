using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;

namespace Zeje.SSO
{
    /// <summary>����MemoryCache�Ļ��渨����
    /// </summary>
    public static class MemoryCacheHelper
    {
        private static readonly Object _locker = new object();

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cachePopulate"></param>
        /// <param name="slidingExpiration"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        public static T GetCacheItem<T>(String key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            if (String.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Invalid cache key");
            if (cachePopulate == null)
                throw new ArgumentNullException("cachePopulate");

            if (slidingExpiration == null && absoluteExpiration == null)
                throw new ArgumentException("Either a sliding expiration or absolute must be provided");

            if (MemoryCache.Default[key] == null)
            {
                lock (_locker)
                {
                    if (MemoryCache.Default[key] == null)
                    {
                        var item = new CacheItem(key, cachePopulate());
                        var policy = CreatePolicy(slidingExpiration, absoluteExpiration);
                        MemoryCache.Default.Add(item, policy);
                    }
                }
            }

            return (T)MemoryCache.Default[key];
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="slidingExpiration"></param>
        /// <param name="absoluteExpiration"></param>
        public static void SetCacheValue<T>(String key, T obj, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            if (MemoryCache.Default[key] == null)
            {
                var item = new CacheItem(key, obj);
                var policy = CreatePolicy(slidingExpiration, absoluteExpiration);
                MemoryCache.Default.Add(item, policy);
            }
            else
            {
                MemoryCache.Default[key] = obj;
            }
        }


        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="slidingExpiration"></param>
        /// <param name="absoluteExpiration"></param>
        public static void ClearCache(String key)
        {
            if (MemoryCache.Default[key] != null)
            {
                MemoryCache.Default.Remove(key);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="slidingExpiration"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        private static CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
        {
            var policy = new CacheItemPolicy();

            if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            else if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }

            policy.Priority = CacheItemPriority.Default;

            return policy;
        }
    }
}

