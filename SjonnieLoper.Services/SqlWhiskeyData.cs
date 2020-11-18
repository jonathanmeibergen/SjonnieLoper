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
    public class SqlWhiskeyData : IWhiskeys
    {
        private ApplicationDbContext _db;

        public SqlWhiskeyData(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Whiskey>> AllWhiskeys() => 
            await _db.Whiskeys.Include(wt => wt.WhiskeyType)
                .OrderByDescending(o => o.WhiskeyType)
                .ToListAsync();

        public async Task<Whiskey> WhiskeyById(int id) =>
            await _db.Whiskeys.Include(d => d.WhiskeyType)
                .FirstAsync(w => w.Id == id);

        public async Task<IEnumerable<Whiskey>> WhiskeyByType(string typeName) =>
            await _db.Whiskeys.Select(w => w)
                .Where(t => t.WhiskeyType.Name == typeName)
                .ToListAsync();

        public async Task<IEnumerable<WhiskeyType>> GetWhiskeyTypes() =>
           await _db.WhiskeyTypes
               .OrderBy( wt => wt.Name)
               .Select(wt => wt)
               .ToListAsync();

        public async Task<Whiskey> Update(Whiskey updatedWhiskey)
        {
            var entity = await Task.FromResult(_db.Whiskeys.Attach(updatedWhiskey));
            entity.State = EntityState.Modified;
            return await Task.FromResult(updatedWhiskey);
        }

        public async Task<Whiskey> Create(Whiskey newWhiskey)
        {
            await _db.Whiskeys.AddAsync(newWhiskey);
            return newWhiskey;
        }

        public Task<int> Commit() => _db.SaveChangesAsync();

        public async Task<Whiskey> Delete(int id)
        {
            var whiskey = await WhiskeyById(id);

            if (whiskey != null)
            {
                _db.Whiskeys.Remove(whiskey);
                await Commit();
            }
            return whiskey;
        }

        public async Task<IEnumerable<Whiskey>> WhiskeyByName(string name) =>
            await _db.Whiskeys
                .Select(w => w)
                .Where(t => t.Name == name)
                .Select(item => item).ToListAsync();

        public async Task<IEnumerable<Whiskey>> WhiskeysByType(WhiskeyType whiskeyType) =>
            await _db.Whiskeys
                .Where(w => w.WhiskeyType.Name == whiskeyType.Name)
                .Select(w => w).ToListAsync();

        public async Task<WhiskeyType> GetWhiskeyTypeById(int Id) =>
            await _db.WhiskeyTypes.Where(wt => wt.Id == Id)
                .SingleOrDefaultAsync();

        public async Task<WhiskeyType> CreateWhiskeyType(string newWhiskeyType)
        {
            if (await _db.WhiskeyTypes.AnyAsync(wt => wt.Name == newWhiskeyType))
                return _db.WhiskeyTypes.First(wt => wt.Name == newWhiskeyType);

            return (await _db.WhiskeyTypes.AddAsync(new WhiskeyType { Name = newWhiskeyType })).Entity;
        }
    }
}