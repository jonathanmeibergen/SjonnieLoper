using System.Collections.Generic;
using System.Linq;
using SjonnieLoper.Services.DataModels.Core.Models;

namespace SjonnieLoper.Services.DataModels.Services
{
    public interface IWhiskeys
    {
        IEnumerable<Whiskey> AllWhiskeys();
        Whiskey WhiskeyById(int id);
        IEnumerable<Whiskey> WhiskeysByType(WhiskeyType whiskeyType);
        public Whiskey Update(Whiskey updatedWhiskey);
        public Whiskey Create(Whiskey newWhiskey);
        public int Commit();
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
            _whiskeys.SingleOrDefault(r => r.WhiskeyId == id);

        public IEnumerable<Whiskey> WhiskeysByType(WhiskeyType whiskeyType) =>
            _whiskeys.Where(w => w.WhiskeyType
                .Name == whiskeyType.Name)
                .Select(w => w);
        public Whiskey Update(Whiskey updatedWhiskey)
        {
            var checkWhiskey = 
                _whiskeys
                    .SingleOrDefault(r => r.WhiskeyId == updatedWhiskey.WhiskeyId);
            return checkWhiskey != null
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

        public int Commit() => 0;
    }
}
