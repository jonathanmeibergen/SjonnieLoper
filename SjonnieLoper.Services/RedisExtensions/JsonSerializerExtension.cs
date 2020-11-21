using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using static Microsoft.Extensions.DependencyInjection.IServiceCollection;

namespace SjonnieLoper.Services.RedisExtensions
{
    public static class DistributedCacheExtensions
    {

    #region Serializers

    

        public static async Task SetRecordAsync<T>(this IDatabase cache,
            string recordId,
            T data,
            TimeSpan? absoluteExpireTime = null,
            TimeSpan? unusedExpireTime = null)
        {
            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime
                                                      ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = unusedExpireTime;

            var jsonData = JsonSerializer.Serialize(data);
            var a = cache.StringSet(recordId, jsonData);
            var c = "cool";
        }

        public static async Task<T> GetRecordAsync<T>(this IDatabase cache,
            string recordId)
        {
            var jsonData = await cache.StringGetAsync(recordId);
            if (jsonData == "nil" )
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(jsonData);
        }
        
    #endregion
    
    }
}