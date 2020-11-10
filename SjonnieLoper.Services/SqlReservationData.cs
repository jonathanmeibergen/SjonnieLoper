using System;
using System.Collections.Generic;
using System.Linq;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public class SqlReservationData : IReservations
    {
        private ApplicationDbContext _db;

        public SqlReservationData(ApplicationDbContext db)
        {
            _db = db;
        } 
        
        public IEnumerable<Reservation> AllReservations() => _db.Reservations;

        public Reservation ReservationByCustId(int id) =>
            _db.Reservations.FirstOrDefault(w => w.Id == id);

        public Reservation ReservationById(int id) =>
            _db.Reservations.SingleOrDefault(r => r.Id == id);

        public IEnumerable<Reservation> ReservationsCustomerName(string name) =>
            _db.Reservations.Select(r => r)
                .Where(entry => entry.Customer == name)
                .Select(x => x);

        public Reservation Update(Reservation updatedReservation)
        {
            var checkReservation = 
                _db.Reservations.SingleOrDefault(r => r.Id == updatedReservation.Id);
            return checkReservation != null
                ? updatedReservation
                : null;
        }

        public Reservation Create(Reservation newReservation)
        {
            _db.Reservations.Add(newReservation);
            newReservation.Id = 
                _db.Reservations.Max(e => e.Id) + 1;
            return newReservation;
        }

        public int Commit() => 0;
    }
}