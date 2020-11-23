using System;
using System.Collections;
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
            return null;
        }

        public async Task<IEnumerable<Whiskey>> GetByName(string name)
        {
            string recordkey = "whiskey_" + DateTime.Now.ToString("yyyyMMdd_hhmm");
            var result = _dbInstance
                .GetRecordAsync<Whiskey>(recordkey);
                // TODO: Call create
            await _dbInstance.SetSingleStringObjAsync(recordkey, result);
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

        public IEnumerable<WhiskeyType> GetAllTypes()
        {
            var hKey = "products:WhiskeyTypes";
            var k = _dbInstance.HashGetAll(hKey)
                .Select(f => JsonSerializer.Deserialize<WhiskeyType>(f.Value));

            return !k.Any() ? null : k;
        }

        public WhiskeyType GetTypeById(int id)
        {
            // TODO: Get id from whiskeyType hash set & inter
            
            var rid = "product:WhiskeyTypes";
            var result =_dbInstance.HashGet(rid, id);
            return result.DeserializeBasic<WhiskeyType>();
            return null;
        }

        public Task<WhiskeyType> CreateType(WhiskeyType newWhiskeyType)
        {
            // Save a a hash set with id of type as field and object as value
            // for reference and retrieve.
            var hKey = "products:WhiskeyTypes";
            var whiskeyTypeId = newWhiskeyType.Id;
            WhiskeyType typeObj = newWhiskeyType;
            var tst = JsonConvert.SerializeObject(typeObj);
            HashEntry[] typeH =
            {
                new HashEntry(whiskeyTypeId, tst)
            };
            _dbInstance.HashSet(hKey, typeH);
            var k = _dbInstance.HashGetAll(hKey);
            
            return Task.FromResult(newWhiskeyType);
        }

        public Whiskey Update(Whiskey updatedWhiskey) =>
            Create(updatedWhiskey);

        public Whiskey Create(Whiskey newWhiskey)
        {
            // TODO: Create/check SADD -> WhiskeyType(k:typename, V:id)<-- NOT A HASHSET PLEASE!
            string typeSetKey  = $"product:WhiskeyTypes:{newWhiskey.WhiskeyType.Id}";
            string whiskeyType = newWhiskey.WhiskeyType.Name;
            string prodId = newWhiskey.Id.ToString();

            // Set per whiskey type holding associated product ids.
            newWhiskey.WhiskeyType.SerializedSetTypes(_dbInstance.SetAdd,
                typeSetKey,
                prodId);

            string nameSetKey = "product:whiskey:name";
            string prodNameKey = newWhiskey.Name;
            string prodIdVal = newWhiskey.Id.ToString();
            // Add name of product(field) associated to product id(value) to hash field for
            // search by name functionality.
             newWhiskey.SerializedHashAsync(_dbInstance.HashSetAsync,
                prodNameKey,
                  prodIdVal);
            
            var typeSet = _dbInstance.HashGetAll(typeSetKey);
            var nameSet = _dbInstance.HashGetAll(nameSetKey);

            var rid = $"product:whiskey:{newWhiskey.Id.ToString()}";
            
            _ = _dbInstance.SetSingleStringObjAsync(rid, newWhiskey);
            return newWhiskey;
        }

        public void Commit(int id)
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

        public async Task UpdateWhiskeySet(IEnumerable<Whiskey> whiskeys)
        {
            // Update whiskey entries.
            // Maintain a set of all keys to whiskeys.
            
            var keyProd = "products:whiskey";
            var keyProdIdHash = "products:allWhiskey";
            // Serialize all objects and add in one roundtrip as array of KvP.
            _dbInstance.BatchAddStringWhiskey(whiskeys, keyProd);
            
            // Save EF id's as values in a set:
            var prodIds = whiskeys.Select(v => v.Id);
            RedisValue[] batchIds = SjonnieRedisUtils
                .BatchRedisArraySerializer(prodIds);
            await _dbInstance.SetAddAsync(keyProdIdHash , batchIds);
            
            var a = _dbInstance.SetMembers(keyProdIdHash);
        }

        public Task UpdateTypeOfWhiskey(IEnumerable<WhiskeyType> types)
        {
            return null;
        }
    }
}