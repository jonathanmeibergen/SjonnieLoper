using System.Collections.Generic;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
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
}
