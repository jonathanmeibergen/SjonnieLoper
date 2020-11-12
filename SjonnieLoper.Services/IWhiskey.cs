using System.Collections.Generic;
using System.Linq;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public interface IWhiskeys
    {
        IEnumerable<Whiskey> AllWhiskeys();
        IEnumerable<Whiskey> WhiskeyByName(string name);
        Whiskey WhiskeyById(int id);
        IEnumerable<Whiskey> WhiskeysByType(WhiskeyType whiskeyType);
        public Whiskey Update(Whiskey updatedWhiskey);
        public Whiskey Create(Whiskey newWhiskey);
        /*public IEnumerable<string> WhiskeyCategories();*/
        public int Commit();
        public Whiskey Delete(int id);
    }
}
