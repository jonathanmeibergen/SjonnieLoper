using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        
        public IEnumerable<Reservation> AllReservations() => 
            _db.Reservations.OrderByDescending( r => r.Orderdate);

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
            var entity = _db.Reservations.Attach(updatedReservation);
            entity.State = EntityState.Modified;
            return updatedReservation;
        }

        public Reservation Create(Reservation newReservation)
        {
            _db.Reservations.Add(newReservation);
            return newReservation;
        }
        
        public int Commit() => _db.SaveChanges();
        
        public Reservation Delete(int id)
        {
            var reservation = ReservationById(id);

            if (reservation != null)
            {
                _db.Reservations.Remove(reservation);
            }

            return reservation;
        }
    }
}