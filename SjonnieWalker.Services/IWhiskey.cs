using System.Collections.Generic;

namespace SjonnieLoper.Core
{
    public interface IWhiskeys
    {
        IEnumerable<Whiskey> AllWhiskeys();
    }
}