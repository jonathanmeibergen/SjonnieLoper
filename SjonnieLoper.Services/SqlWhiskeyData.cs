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
            _db.Whiskeys.FirstOrDefault(w => w.WhiskeyId == id);

        public IEnumerable<Whiskey> WhiskeyByType(string typeName) =>
            _db.Whiskeys.Select(w => w)
                .Where(t => t.WhiskeyType.Name == typeName);

        public Whiskey Update(Whiskey updatedWhiskey)
        {
            var reservation = 
                _db.Whiskeys.SingleOrDefault(r => r.WhiskeyId == updatedWhiskey.WhiskeyId);
            return reservation != null
                ? updatedWhiskey
                : null;
        }

        public Whiskey Create(Whiskey newWhiskey)
        {
            _db.Whiskeys.Add(newWhiskey);
            newWhiskey.WhiskeyId = 
                _db.Whiskeys.Max(e => e.WhiskeyId) + 1;
            return newWhiskey;
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }
    }
}
