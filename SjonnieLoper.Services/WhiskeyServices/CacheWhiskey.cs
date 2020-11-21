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
        private readonly IConnectionMultiplexer _cache;
        private IDatabase _dbInstance;
        public CacheWhiskey(IConnectionMultiplexer cache)
        {
            _cache = cache;
        }

        public Task<IEnumerable<Whiskey>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Whiskey>> GetByName(string name)
        {
            _dbInstance = _cache.GetDatabase();
            string recordkey = "whiskey_" + DateTime.Now.ToString("yyyyMMdd_hhmm");
            var result = _dbInstance
                .GetRecordAsync<Whiskey>(recordkey);
                // TODO: Call create
            await _dbInstance.SetRecordAsync(recordkey, result);
            return null;
        }

        public Task<Whiskey> GetById(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            // TODO: Change to create.
            var rid = newWhiskey.Id.ToString();
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