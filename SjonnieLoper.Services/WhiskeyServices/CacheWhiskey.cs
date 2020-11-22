using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services.RedisExtensions;
using StackExchange.Redis;

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
            string prodKey = $"whiskey:{id.ToString()}";
            return await _dbInstance.GetRecordAsync<Whiskey>(prodKey);
        }

        public Task<IEnumerable<Whiskey>> GetByType(WhiskeyType whiskeyType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WhiskeyType>> GetAllTypes()
        {
            throw new NotImplementedException();
        }

        public Task<WhiskeyType> GetTypeById(int id)
        {
            // TODO: Get id from whiskeyType hash set & inter
            
            var rid = $"whiskey:{id.ToString()}";
            
            /*await _dbInstance.SetRecordAsync(rid);
            var a  = await _dbInstance.GetRecordAsync<Whiskey>(rid);
            Console.WriteLine(a);*/
            return null;
        }

        public Task<WhiskeyType> CreateType(string newWhiskeyType)
        {
            throw new NotImplementedException();
        }

        public Task<Whiskey> Update(Whiskey updatedWhiskey)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Whiskey> Create(Whiskey newWhiskey)
        {
            // TODO: Create/check SADD -> WhiskeyType(k:typename, V:id)<-- NOT A HASHSET PLEASE!
            // TODO: Create/check SADD -> WhiskeyName(k:productName, v: id)
            // TODO: Create/update objects serialized SET -> (K:whiskey:prodId V:obj serialized)
            string typeSetKey  = "whiskey:type";
            string whiskeyType = newWhiskey.WhiskeyType.Name;
            string prodId = newWhiskey.Id.ToString();
            HashEntry[] typeH =
            {
                new HashEntry(whiskeyType, prodId)
            };
            _dbInstance.HashSet(typeSetKey, typeH);

            string nameSetKey = "whiskey:name";
            string prodNameKey = newWhiskey.Name;
            string prodIdVal = newWhiskey.Id.ToString();
            HashEntry[] nameH =
            {
                new HashEntry(prodNameKey, prodIdVal)
            };
            _dbInstance.HashSet(nameSetKey, nameH);

            var typeSet = _dbInstance.HashGetAll(typeSetKey);
            var nameSet = _dbInstance.HashGetAll(nameSetKey);

            var rid = $"whiskey:{newWhiskey.Id.ToString()}";
            
            await _dbInstance.SetRecordAsync(rid, newWhiskey);
            var a  = await _dbInstance.GetRecordAsync<Whiskey>(rid);
            Console.WriteLine(a);
            return null;
        }

        public Task<int> Commit()
        {
            throw new System.NotImplementedException();
        }

        public Task<Whiskey> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}