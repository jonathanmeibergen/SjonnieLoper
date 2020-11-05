using System;
using System.Collections.Generic;
using System.Linq;
using SjonnieLoper.Core.Models;

namespace SjonieLoper.Services
{
    public interface IWhiskeys
    {
        IEnumerable<Whiskey> AllWhiskeys();
        Whiskey WhiskeyById(int ond);
        IEnumerable<Whiskey> WhiskeyByType(string typeName);
        Whiskey Update(Whiskey updatedWhiskey);
        Whiskey Create(Whiskey newWhiskey);
        int Commit();
    }

    public class Mock_Whiskey : IWhiskeys
    {
        private List<Whiskey> _whiskeys;

        public Mock_Whiskey()
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
