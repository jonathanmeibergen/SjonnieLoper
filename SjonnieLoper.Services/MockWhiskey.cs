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
        public Whiskey WhiskeyById(int id) => 
            _whiskeys.FirstOrDefault(w => w.WhiskeyId == id);

        public IEnumerable<Whiskey> WhiskeyByType(string typeName) =>
            _whiskeys.Select(w => w)
                .Where(t => t.WhiskeyType.Name == typeName);

        public Whiskey Update(Whiskey updatedWhiskey)
        {
            var reservation = 
                _whiskeys.SingleOrDefault(r => r.WhiskeyId == updatedWhiskey.WhiskeyId);
            return reservation != null
                ? updatedWhiskey
                : null;
        }

        public Whiskey Create(Whiskey newWhiskey)
        {
            _whiskeys.Add(newWhiskey);
            newWhiskey.WhiskeyId = 
                _whiskeys.Max(e => e.WhiskeyId) + 1;
            return newWhiskey;
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }
    }
}
