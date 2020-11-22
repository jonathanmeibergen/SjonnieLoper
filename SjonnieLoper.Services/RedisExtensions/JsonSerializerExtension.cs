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
    public static partial class DistributedCacheExtensions
    {

    #region Serializers

        public static async Task SerializedHashAsync<T>(this T obj,
            Func<RedisKey, HashEntry[], CommandFlags, Task> redisFunc,
            string field,
            string key)
        {
            var jsonData = JsonSerializer.Serialize(obj);
            HashEntry[] entry =
            {
                new HashEntry(field, jsonData)
            };
            await redisFunc(key, entry, CommandFlags.None);
        } 

        public static async Task SetRecordAsync<T>(this IDatabase cache,
            string recordId,
            T data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            await cache.StringSetAsync(recordId, jsonData);
        }

        public static async Task<T> GetRecordAsync<T>(this IDatabase cache,
            string recordId)
        {
            var jsonData = await cache.StringGetAsync(recordId);
            if (jsonData.IsNull)
            {
                return default(T);
            }
            
            return JsonSerializer.Deserialize<T>(jsonData);
        }
        
    #endregion
    
    }
}