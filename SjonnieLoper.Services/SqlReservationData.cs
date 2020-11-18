using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Reservation>> AllReservations() =>
            await _db.Reservations.Include( p => p.Product)
                .Include(u => u.User)
                .OrderByDescending(r => r.Orderdate).ToListAsync();

        public async Task<Reservation> ReservationByCustId(int id) =>
            await _db.Reservations.FirstOrDefaultAsync(w => w.Id == id);

        public Task<Reservation> ReservationById(int id) =>
            _db.Reservations.SingleOrDefaultAsync(r => r.Id == id);

        public async Task<IEnumerable<Reservation>> ReservationsUserName(string name) =>
            await _db.Reservations.Include(u => u.User)
                            .Select(r => r)
                            .Where(entry => entry.User.UserName == name)
                            .Select(x => x)
                            .Include(p => p.Product).ToListAsync();

        public async Task <Reservation> Update(Reservation updatedReservation)
        {
            var entity = _db.Reservations.Attach(updatedReservation);
            entity.State = EntityState.Modified;
            return await Task.FromResult(updatedReservation);
        }

        public async Task <Reservation> Create(Reservation newReservation)
        {
            await _db.Reservations.AddAsync(newReservation);
            return newReservation;
        }
        
        public async Task <int> Commit() => await _db.SaveChangesAsync();
        
        public async Task <Reservation> Delete(int id)
        {
            var reservation = await ReservationById(id);

            if (reservation != null)
            {
                _db.Reservations.Remove(reservation);
            }

            return reservation;
        }
    }
}