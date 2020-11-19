using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Whiskey> GetAll() => 
            _db.Whiskeys.Include(wt => wt.WhiskeyType).OrderByDescending(o => o.WhiskeyType);

        public Whiskey GetById(int id) =>
            _db.Whiskeys.Include(d => d.WhiskeyType).First(w => w.Id == id);

        public IEnumerable<Whiskey> WhiskeyByType(string typeName) =>
            _db.Whiskeys.Select(w => w)
                .Where(t => t.WhiskeyType.Name == typeName);

        public IEnumerable<WhiskeyType> GetTypes() =>
            _db.WhiskeyTypes.OrderBy( wt => wt.Name).Select(wt => wt);

        public Whiskey Update(Whiskey updatedWhiskey)
        {
            var entity = _db.Whiskeys.Attach(updatedWhiskey);
            entity.State = EntityState.Modified;
            return updatedWhiskey;
        }

        public Whiskey Create(Whiskey newWhiskey)
        {
            _db.Whiskeys.Add(newWhiskey);
            return newWhiskey;
        }

        public int Commit() => _db.SaveChanges();

        public Whiskey Delete(int id)
        {
            var whiskey = GetById(id);

            if (whiskey != null)
            {
                _db.Whiskeys.Remove(whiskey);
                Commit();
            }
            return whiskey;
        }

        public IEnumerable<Whiskey> GetByName(string name) =>
            _db.Whiskeys
                .Select(w => w)
                .Where(t => t.Name == name)
                .Select(item => item);

        public IEnumerable<Whiskey> GetByType(WhiskeyType whiskeyType) =>
            _db.Whiskeys
                .Where(w => w.WhiskeyType.Name == whiskeyType.Name)
                .Select(w => w);

        public WhiskeyType GetTypeById(int Id) =>
            _db.WhiskeyTypes.Where(wt => wt.Id == Id).SingleOrDefault();

        public WhiskeyType CreateType(string newWhiskeyType)
        {
            if (_db.WhiskeyTypes.Any(wt => wt.Name == newWhiskeyType))
                return _db.WhiskeyTypes.First(wt => wt.Name == newWhiskeyType);

            return _db.WhiskeyTypes.Add(new WhiskeyType { Name = newWhiskeyType }).Entity;
        }
    }
}