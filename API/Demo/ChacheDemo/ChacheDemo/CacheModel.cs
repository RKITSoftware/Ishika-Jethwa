using System;
using System.Web.Caching;

namespace ChacheDemo
{

    public class CacheModel
    {
        private static Cache _cache = null;
        private static Cache cache
        {

            get
            {

                if (_cache == null)
                    _cache = (System.Web.HttpContext.Current == null) ? System.Web.HttpRuntime.Cache : System.Web.HttpContext.Current.Cache;

                return _cache;
            }
            set
            {
                _cache = value;
            }


        }
        /// <summary>
        /// Retrieves an object from the cache based on the specified key.
        /// </summary>
        /// <param name="key">The key associated with the cached object.</param>
        /// <returns>The cached object, or null if not found.</returns>
        public static object Get(string key)
        {
            return cache.Get(key);
        }
        /// <summary>
        /// Adds an object to the cache with the specified key.
        /// </summary>
        /// <param name="key">The key to associate with the cached object.</param>
        /// <param name="value">The object to be cached.</param>
        public static void Add(string key, object value)
        {
          
            cache.Insert(key, value);
        }
        /// <summary>
        /// Removes the cached object associated with the specified key.
        /// </summary>
        /// <param name="key">The key of the object to be removed from the cache.</param>
        public static void Remove(string key)
        {
            cache.Remove(key);
        }


    }
}
