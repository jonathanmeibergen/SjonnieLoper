using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public interface ISqlWhiskeys
    {
        Task<IEnumerable<Whiskey>> GetAll();
        Task<IEnumerable<Whiskey>> GetByName(string name);
        Task<Whiskey> GetById(int id);
        Task<IEnumerable<Whiskey>> GetByType(WhiskeyType whiskeyType);
        Task<IEnumerable<WhiskeyType>> GetAllTypes();
        Task<WhiskeyType> GetTypeById(int Id);
        Task<WhiskeyType> CreateType(string newWhiskeyType);
        Task <Whiskey> Update(Whiskey updatedWhiskey);
        Task <Whiskey> Create(Whiskey newWhiskey);
        /*public IEnumerable<string> WhiskeyCategories();*/
        Task<int> Commit();
        Task<Whiskey> Delete(int id);
    }
}
