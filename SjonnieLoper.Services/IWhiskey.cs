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
        IEnumerable<Whiskey> WhiskeyByType();
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
        public Whiskey WhiskeyById(int ond)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Whiskey> WhiskeyByType()
        {
            throw new NotImplementedException();
        }

        public Whiskey Update(Whiskey updatedWhiskey)
        {
            throw new NotImplementedException();
        }

        public Whiskey Create(Whiskey newWhiskey)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }
    }
}
