using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

        public IEnumerable<Whiskey> AllWhiskeys() => _db.Whiskeys;
        public Whiskey WhiskeyById(int id) => 
            _db.Whiskeys.FirstOrDefault(w => w.Id == id);

        public IEnumerable<Whiskey> WhiskeyByType(string typeName) =>
            _db.Whiskeys.Select(w => w)
                .Where(t => t.WhiskeyType.Name == typeName);

        public Whiskey Update(Whiskey updatedWhiskey)
        {
            var reservation = 
                _db.Whiskeys.SingleOrDefault(r => r.Id == updatedWhiskey.Id);
            return reservation != null
                ? updatedWhiskey
                : null;
        }

        public Whiskey Create(Whiskey newWhiskey)
        {
            _db.Whiskeys.Add(newWhiskey);
            newWhiskey.Id = 
                _db.Whiskeys.Max(e => e.Id) + 1;
            return newWhiskey;
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Whiskey> WhiskeyByName(string name) =>
           _db.Whiskeys
           .Select(w => w)
           .Where(t => t.Name == name)
           .Select(item => item);

        public IEnumerable<Whiskey> WhiskeysByType(WhiskeyType whiskeyType) =>
            _db.Whiskeys
            .Where(w => w.WhiskeyType.Name == whiskeyType.Name)
            .Select(w => w);
    }
}
