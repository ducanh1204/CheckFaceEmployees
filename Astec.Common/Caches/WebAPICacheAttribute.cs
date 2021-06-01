using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Astec.Common.Caches
{
    public class WebAPICacheAttribute : ActionFilterAttribute
    {
        public int Duration { get; set; }

        private bool CacheEnabled = false;
        private int _timespan;
        // true to enable cache
       // private bool _cacheEnabled = false;
        // true if the cache depends on the caller user
        //private readonly bool _dependsOnIdentity;
        // cache repository
        private static readonly ObjectCache WebApiCache = MemoryCache.Default;
        //private readonly SecurityHelper _securityHelper;
        //private readonly bool _invalidateCache;


        public WebAPICacheAttribute(int _duration, bool _cacheEnabled)
        {
            Duration = _duration;

            CacheEnabled = _cacheEnabled;
        }

        public override void OnActionExecuting(HttpActionContext context)
        {
            if (CacheEnabled)
            {
                if (context != null)

                {
                    //generate cache key from HTTP request URI and Header

                    string _cachekey = string.Join(":", new string[]
                    {
                            context.Request.RequestUri.OriginalString,

                            context.Request.Headers.Accept.FirstOrDefault().ToString(),
                    });

                    // Check Key exists

                    if (MemoryCacher.Contains(_cachekey))
                    {
                        var val = (string)MemoryCacher.GetValue(_cachekey);

                        if (val != null)
                        {
                            context.Response = context.Request.CreateResponse();

                            context.Response.Content = new StringContent(val);

                            var contenttype = (MediaTypeHeaderValue)MemoryCacher.GetValue(_cachekey +

                        ":response-ct");

                            if (contenttype == null)

                                contenttype = new MediaTypeHeaderValue(_cachekey.Split(':')[1]);

                            context.Response.Content.Headers.ContentType = contenttype;

                            return;
                        }
                    }
                }
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext context)
        {
            if (CacheEnabled)
            {
                if (WebApiCache != null)
                {
                    string _cachekey = string.Join(":", new string[]
                    {
                            context.Request.RequestUri.OriginalString,

                            context.Request.Headers.Accept.FirstOrDefault().ToString(),
                    });

                    if (context.Response != null && context.Response.Content != null)
                    {
                        string body = context.Response.Content.ReadAsStringAsync().Result;

                        if (MemoryCacher.Contains(_cachekey))
                        {
                            MemoryCacher.Add(_cachekey, body, DateTime.Now.AddSeconds(Duration));

                            MemoryCacher.Add(_cachekey + ":response-ct",

                            context.Response.Content.Headers.ContentType,

                            DateTime.Now.AddSeconds(_timespan));
                        }
                        else
                        {
                            MemoryCacher.Add(_cachekey, body, DateTime.Now.AddSeconds(Duration));

                            MemoryCacher.Add(_cachekey + ":response-ct",

                            context.Response.Content.Headers.ContentType,

                            DateTime.Now.AddSeconds(Duration));
                        }
                    }
                }
            }
        }
    }
}