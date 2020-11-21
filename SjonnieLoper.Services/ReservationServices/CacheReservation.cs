using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using SjonnieLoper.Core.Models;
using StackExchange.Redis;

namespace SjonnieLoper.Services
{
    public class CacheReservation : ICacheReservations
    {
        private readonly IDatabase _dbInstance;

        public CacheReservation(IConnectionMultiplexer cache)
        {
            _dbInstance = cache.GetDatabase();
        }
        public Task<IEnumerable<Reservation>> AllReservations()
        {
            throw new System.NotImplementedException();
        }

        public Task<Reservation> ReservationByCustId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Reservation> ReservationById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> ReservationsUserName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<Reservation> Update(Reservation updatedReservation)
        {
            throw new System.NotImplementedException();
        }

        public Task<Reservation> Create(Reservation newReservation)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Commit()
        {
            throw new System.NotImplementedException();
        }

        public Task<Reservation> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}