using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public interface IWhiskeys
    {
        Task<IEnumerable<Whiskey>> AllWhiskeys();
        Task<IEnumerable<Whiskey>> WhiskeyByName(string name);
        Task<Whiskey> WhiskeyById(int id);
        Task<IEnumerable<Whiskey>> WhiskeysByType(WhiskeyType whiskeyType);
        Task<IEnumerable<WhiskeyType>> GetWhiskeyTypes();
        Task<WhiskeyType> GetWhiskeyTypeById(int Id);
        Task<WhiskeyType> CreateWhiskeyType(string newWhiskeyType);
        Task <Whiskey> Update(Whiskey updatedWhiskey);
        Task <Whiskey> Create(Whiskey newWhiskey);
        /*public IEnumerable<string> WhiskeyCategories();*/
        Task<int> Commit();
        Task<Whiskey> Delete(int id);
    }
}
