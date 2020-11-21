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
            var inst = "Life!!";
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
            string prodKey = $"product:{id.ToString()}";
            var a  = await _dbInstance.GetRecordAsync<Whiskey>(prodKey);
            Console.WriteLine(a);
            return null;
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
            var rid = "product:"+newWhiskey.Id.ToString();
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