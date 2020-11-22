using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public class SqlSqlWhiskeyData : ISqlWhiskeys
    {
        private ApplicationDbContext _db;

        public SqlSqlWhiskeyData(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Whiskey>> GetAll() => 
            await _db.Whiskeys.Include(wt => wt.WhiskeyType)
                .OrderByDescending(o => o.WhiskeyType)
                .ToListAsync();

        public async Task<Whiskey> GetById(int id) =>
            await _db.Whiskeys.Include(d => d.WhiskeyType)
                .FirstAsync(w => w.Id == id);

        public async Task<IEnumerable<Whiskey>> WhiskeyByType(string typeName) =>
            await _db.Whiskeys.Select(w => w)
                .Where(t => t.WhiskeyType.Name == typeName)
                .ToListAsync();

        public async Task<IEnumerable<WhiskeyType>> GetAllTypes() =>
           await _db.WhiskeyTypes
               .OrderBy( wt => wt.Name)
               .Select(wt => wt)
               .ToListAsync();

        public Whiskey Update(Whiskey updatedWhiskey)
        {
            var entity = _db.Whiskeys.Attach(updatedWhiskey);
            entity.State = EntityState.Modified;
            return updatedWhiskey;
        }

        public async Task<Whiskey> Create(Whiskey newWhiskey)
        {
            await _db.Whiskeys.AddAsync(newWhiskey);
            return newWhiskey;
        }

        public Task<int> Commit() => _db.SaveChangesAsync();

        public async Task<Whiskey> Delete(int id)
        {
            var whiskey = await GetById(id);

            if (whiskey != null)
            {
                _db.Whiskeys.Remove(whiskey);
                await Commit();
            }
            return whiskey;
        }

        public async Task<IEnumerable<Whiskey>> GetByName(string name) =>
            await _db.Whiskeys
                .Select(w => w)
                .Where(t => t.Name == name)
                .Select(item => item).ToListAsync();

        public async Task<IEnumerable<Whiskey>> GetByType(WhiskeyType whiskeyType) =>
            await _db.Whiskeys
                .Where(w => w.WhiskeyType.Name == whiskeyType.Name)
                .Select(w => w).ToListAsync();

        public async Task<WhiskeyType> GetTypeById(int id) =>
            await _db.WhiskeyTypes.Where(wt => wt.Id == id)
                .SingleOrDefaultAsync();

        public async Task<WhiskeyType> CreateType(WhiskeyType newWhiskeyType)
        {
            if (await _db.WhiskeyTypes.AnyAsync(wt => wt.Name == newWhiskeyType.Name))
                return _db.WhiskeyTypes
                    .First(wt => wt.Name == newWhiskeyType.Name);

            return (await _db.WhiskeyTypes.AddAsync(new WhiskeyType { Name = newWhiskeyType.Name })).Entity;
        }
    }
}