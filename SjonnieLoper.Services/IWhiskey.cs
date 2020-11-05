using System;
using System.Collections.Generic;
using System.Linq;
using SjonnieLoper.Core.Models;

namespace SjonieLoper.Services
{
    public interface IWhiskeys
    {
        IEnumerable<Whiskey> AllWhiskeys();
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
    }
}
