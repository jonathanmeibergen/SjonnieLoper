using System.Collections.Generic;
using SjonnieLoper.Core.Models;

namespace SjonieLoper.Services
{
    public interface IWhiskeys
    {
        IEnumerable<Whiskey> AllWhiskeys();
    }
}