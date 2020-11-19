using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public interface IWhiskeys
    {
        IEnumerable<Whiskey> GetAll();
        IEnumerable<Whiskey> GetByName(string name);
        Whiskey GetById(int id);
        IEnumerable<Whiskey> GetByType(WhiskeyType whiskeyType);
        IEnumerable<WhiskeyType> GetTypes();
        WhiskeyType GetTypeById(int Id);
        WhiskeyType CreateType(string newWhiskeyType);
        public Whiskey Update(Whiskey updatedWhiskey);
        public Whiskey Create(Whiskey newWhiskey);
        /*public IEnumerable<string> WhiskeyCategories();*/
        public int Commit();
        public Whiskey Delete(int id);
    }
}
