using System.Collections.Generic;
using Core;

namespace SjonnieLoper.Core
{
    public interface IWhiskeys
    {
        IEnumerable<Whiskey> AllWhiskeys();
    }
}