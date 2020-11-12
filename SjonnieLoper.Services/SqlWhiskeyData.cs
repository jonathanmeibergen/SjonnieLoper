﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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

        public IEnumerable<Whiskey> AllWhiskeys() => 
            _db.Whiskeys.OrderByDescending(o => o.WhiskeyType);

        public Whiskey WhiskeyById(int id) =>
            _db.Whiskeys.FirstOrDefault(w => w.Id == id);

        public IEnumerable<Whiskey> WhiskeyByType(string typeName) =>
            _db.Whiskeys.Select(w => w)
                .Where(t => t.WhiskeyType.Name == typeName);

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
            var whiskey = WhiskeyById(id);

            if (whiskey != null)
            {
                _db.Whiskeys.Remove(whiskey);
                Commit();
            }
            return whiskey;
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