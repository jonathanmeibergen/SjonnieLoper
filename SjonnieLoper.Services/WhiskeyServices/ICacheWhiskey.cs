using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public interface ICacheWhiskey : ISqlWhiskeys
    {
        Task UpdateWhiskeySet(IEnumerable<Whiskey> whiskeys);
        Task UpdateTypeOfWhiskey(IEnumerable<WhiskeyType> types);
    }
}