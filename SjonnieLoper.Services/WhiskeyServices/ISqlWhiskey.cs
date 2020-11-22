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
        Task<WhiskeyType> GetTypeById(int id);
        Task<WhiskeyType> CreateType(WhiskeyType newWhiskeyType);
        Whiskey Update(Whiskey updatedWhiskey);
        Task <Whiskey> Create(Whiskey newWhiskey);
        Task<int> Commit(int id);
        Task<Whiskey> Delete(int id);
    }
}
