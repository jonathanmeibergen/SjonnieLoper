using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services.RedisExtensions;
using StackExchange.Redis;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace SjonnieLoper.Services
{
    public class CacheWhiskey : ICacheWhiskey
    {
        private readonly IDatabase _dbInstance;
        public CacheWhiskey(IConnectionMultiplexer cacheDb)
        {
            _dbInstance = cacheDb.GetDatabase();
        }

        public Task<IEnumerable<Whiskey>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Whiskey>> GetByName(string name)
        {
            string recordkey = "whiskey_" + DateTime.Now.ToString("yyyyMMdd_hhmm");
            var result = _dbInstance
                .GetRecordAsync<Whiskey>(recordkey);
                // TODO: Call create
            await _dbInstance.SetRecordAsync(recordkey, result);
            return null;
        }

        public async Task<Whiskey> GetById(int id)
        {
            string prodKey = $"product:whiskey:{id.ToString()}";
            return await _dbInstance.GetRecordAsync<Whiskey>(prodKey);
        }

        public Task<IEnumerable<Whiskey>> GetByType(WhiskeyType whiskeyType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WhiskeyType>> GetAllTypes()
        {
            var hKey = "products:WhiskeyTypes";
            var k = _dbInstance.HashGetAll(hKey)
                .Select(f => f);
            foreach (var hashEntries in k)
            {
                var val = hashEntries.Value;
                var strVal = val.ToString();
                var it = "Foo";
            }
            return null;
        }

        public Task<WhiskeyType> GetTypeById(int id)
        {
            // TODO: Get id from whiskeyType hash set & inter
            
            var rid = $"product:whiskey:{id.ToString()}";
            
            /*await _dbInstance.SetRecordAsync(rid);
            var a  = await _dbInstance.GetRecordAsync<Whiskey>(rid);
            Console.WriteLine(a);*/
            return null;
        }

        public Task<WhiskeyType> CreateType(WhiskeyType newWhiskeyType)
        {
            // TODO: serialize and add to hashmap
            var hKey = "products:WhiskeyTypes";
            string whiskeyType = newWhiskeyType.Name;
            WhiskeyType typeObj = newWhiskeyType;
            var tst = JsonConvert.SerializeObject(typeObj);
            HashEntry[] typeH =
            {
                new HashEntry(whiskeyType, tst)
            };
            _dbInstance.HashSet(hKey, typeH);
            var k = _dbInstance.HashGetAll(hKey);
            
            
            return Task.FromResult(newWhiskeyType);
        }

        public Whiskey Update(Whiskey updatedWhiskey) => 
            Create(updatedWhiskey).Result;

        public async Task<Whiskey> Create(Whiskey newWhiskey)
        {
            // TODO: Create/check SADD -> WhiskeyType(k:typename, V:id)<-- NOT A HASHSET PLEASE!
            // TODO: Centralize keys.
            string typeSetKey  = "product:whiskey:type";
            string whiskeyType = newWhiskey.WhiskeyType.Name;
            string prodId = newWhiskey.Id.ToString();

            // Add name of whiskey(field) type associated to the whiskey id(value)
            // for search by type name of products later
            await newWhiskey.WhiskeyType.SerializedHashAsync(_dbInstance.HashSetAsync,
                whiskeyType,
                prodId);

            string nameSetKey = "product:whiskey:name";
            string prodNameKey = newWhiskey.Name;
            string prodIdVal = newWhiskey.Id.ToString();

            // Add name of product(field) associated to product id(value) to hash field for
            // search by name functionality.
             await newWhiskey.SerializedHashAsync(_dbInstance.HashSetAsync,
                prodNameKey,
                  prodIdVal);
            
            var typeSet = _dbInstance.HashGetAll(typeSetKey);
            var nameSet = _dbInstance.HashGetAll(nameSetKey);

            var rid = $"product:whiskey:{newWhiskey.Id.ToString()}";
            
            _ = _dbInstance.SetRecordAsync(rid, newWhiskey);
            return newWhiskey;
        }

        public Task<int> Commit(int id)
        {
            // TODO: Add timespan comparison to mirror EF functionality.
            // Fetch expire time of key, can be used to check
            // for commit alongside EF commit functionality.
            var rid = $"product:whiskey:{id.ToString()}";
            _dbInstance.StringGetWithExpiryAsync(rid);
        }

        public async Task<Whiskey> Delete(int id)
        {
            var rid = $"product:whiskey:{id.ToString()}";
             await _dbInstance.KeyDeleteAsync(rid, CommandFlags.FireAndForget);
             return null;
        }

        public Task UpdateWhiskeySet(IEnumerable<Whiskey> whiskeys)
        {
            // Maintain a set of all keys to whiskeys.
            // Update whiskey entries.
            RedisValue[] batchObj = 
            _dbInstance.SetAdd("ProdSetKey", orders);
            return null;
        }

        public Task UpdateTypeOfWhiskey(IEnumerable<WhiskeyType> types)
        {
            throw new NotImplementedException();
        }
    }
}