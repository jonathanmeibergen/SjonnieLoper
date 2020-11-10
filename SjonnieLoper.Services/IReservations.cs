using System;
using System.Collections.Generic;
using System.Linq;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public interface IReservations
    {
        //IEnumerable<string> ReservationWhiskeyTypes();
        IEnumerable<Reservation> AllReservations();
        Reservation ReservationByCustId(int id);
        Reservation ReservationById(int id);
        IEnumerable<Reservation> ReservationsCustomerName(string name);
        Reservation Update(Reservation updatedReservation);
        Reservation Create(Reservation newReservation);
        int Commit();
        
    }

    public class Mock_Reservations : IReservations
    {
        private List<Reservation> _reservations;
        
        public Mock_Reservations()
        {
            _reservations = new List<Reservation>()
            {
                // Using development constructor for whiskey here, not intended for db use later.
                new Reservation( 6, DateTime.Now, new Customer("Iris", "a"), new Whiskey("Old Foo")),
                new Reservation( 5, DateTime.Now, new Customer("Vera", "b"), new Whiskey("Jack Bar")),
                new Reservation( 4, DateTime.Now, new Customer("John", "c"), new Whiskey("Golden Goose")),
                new Reservation( 3, DateTime.Now, new Customer("Erik", "d"), new Whiskey("Monkey Handles")),
                new Reservation( 2, DateTime.Now, new Customer("Phoebe", "e"), new Whiskey("Fizz Buzz")),
                new Reservation( 1, DateTime.Now, new Customer("Mohammed", "f"), new Whiskey("Monkey Handles"))
            };
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