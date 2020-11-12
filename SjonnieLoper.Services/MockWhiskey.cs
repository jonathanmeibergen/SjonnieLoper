using System;
using System.Collections.Generic;
using System.Linq;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public class MockWhiskey : IWhiskeys
    {
        private List<Whiskey> _whiskeys;

        public MockWhiskey()
        {
            _whiskeys = new List<Whiskey>()
            {
                new Whiskey(
                    1,
                    "Grey Goose",
                    20,
                    "Austria",
                    40,
                    "foo/bar/baz.png",
                    new WhiskeyType() {WhiskeyTypeId = 1, Name = "SomeType"})
            };
        }
        public IEnumerable<Whiskey> AllWhiskeys() => _whiskeys;
        public IEnumerable<Whiskey> WhiskeyByName(string name) => 
            _whiskeys
                .Select(w => w)
                .Where(t => t. Name == name)
                .Select(item => item);

        /*
        public IEnumerable<string> WhiskeyCategories() => 
            _whiskeys.Select(w => w)
            .GroupBy(i => i.WhiskeyType).Distinct()
            .Select(s => s);
            */
        
        public Whiskey WhiskeyById(int id) => 
            _whiskeys.SingleOrDefault(r => r.Id == id);

        public IEnumerable<Whiskey> WhiskeysByType(WhiskeyType whiskeyType) =>
            _whiskeys.Where(w => w.WhiskeyType
                    .Name == whiskeyType.Name)
                .Select(w => w);
        public Whiskey Update(Whiskey updatedWhiskey)
        {
            var checkWhiskey = 
                _whiskeys
                    .SingleOrDefault(r => r.Id == updatedWhiskey.Id);
            return checkWhiskey != null
                ? updatedWhiskey
                : null;
        }

        public Whiskey Create(Whiskey newWhiskey)
        {
            _whiskeys.Add(newWhiskey);
            newWhiskey.Id = 
                _whiskeys.Max(e => e.Id) + 1;
            return newWhiskey;
        }

        public int Commit() => 0;
    }
}
