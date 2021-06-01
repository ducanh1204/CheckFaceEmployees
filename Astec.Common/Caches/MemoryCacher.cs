﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Astec.Common.Caches
{
    public static class MemoryCacher
    {
        public static object GetValue(string key)

        {

            MemoryCache memoryCache = MemoryCache.Default;

            return memoryCache.Get(key);

        }


        public static bool Add(string key, object value, DateTimeOffset absExpiration)

        {

            MemoryCache memoryCache = MemoryCache.Default;

            return memoryCache.Add(key, value, absExpiration);

        }


        public static void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;

            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }

        }

        public static bool Contains(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            bool flag = false;
            if (memoryCache.Contains(key))
            {
                flag = true;
            }
            return flag;
        }
    }

}
