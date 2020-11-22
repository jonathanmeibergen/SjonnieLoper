using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace SjonnieLoper.Services.RedisExtensions
{
    public static partial class DistributedCacheExtensions
    {
        public static HashEntry[] ObjectToHash(this object obj)
        {
            PropertyInfo[] objProperties = obj.GetType().GetProperties();
            return objProperties
                .Where(prop => prop.GetValue(obj) != null)
                .Select
                (
                    property =>
                    {
                        object propVal = property.GetValue(obj);
                        string hashVal = propVal is IEnumerable<object>
                            ? JsonConvert.SerializeObject(propVal)
                            : propVal.ToString();
                        return new HashEntry(property.Name, hashVal);
                    }
                ).ToArray();
        }
        
        public static T HashToObject<T>(this string hashedObj)
        {
            return JsonConvert.DeserializeObject<T>(hashedObj);
        }
        
    }
}