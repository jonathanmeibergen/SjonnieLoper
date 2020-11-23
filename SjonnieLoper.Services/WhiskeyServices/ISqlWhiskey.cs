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
        IEnumerable<WhiskeyType> GetAllTypes();
        WhiskeyType GetTypeById(int id);
        Task<WhiskeyType> CreateType(WhiskeyType newWhiskeyType);
        Whiskey Update(Whiskey updatedWhiskey);
        Whiskey Create(Whiskey newWhiskey);
        void Commit(int id);
        Task<Whiskey> Delete(int id);
    }
}
