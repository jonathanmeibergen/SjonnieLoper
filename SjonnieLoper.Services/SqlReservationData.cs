using System.Collections.Generic;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public class SqlReservationData
    {
        private ApplicationDbContext _db;

        public SqlWhiskeyData(ApplicationDbContext db)
        {
            _db = db;
        } 
        
        public IEnumerable<Reservation> AllReservations() => _reservations;

        public Reservation ReservationByCustId(int id) =>
            _reservations.FirstOrDefault(w => w.Id == id);

        public Reservation ReservationById(int id) =>
            _reservations.SingleOrDefault(r => r.Id == id);

        public IEnumerable<Reservation> ReservationsCustomerName(string name) =>
            _reservations.Select(r => r)
                .Where(entry => entry.Customer == name)
                .Select(x => x);

        public Reservation Update(Reservation updatedReservation)
        {
            var checkReservation = 
                _reservations.SingleOrDefault(r => r.Id == updatedReservation.Id);
            return checkReservation != null
                ? updatedReservation
                : null;
        }

        public Reservation Create(Reservation newReservation)
        {
            _reservations.Add(newReservation);
            newReservation.Id = 
                _reservations.Max(e => e.Id) + 1;
            return newReservation;
        }

        public int Commit() => 0;
        
        
    }
}