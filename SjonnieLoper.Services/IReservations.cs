using System;
using System.Collections.Generic;
using System.Linq;
using SjonnieLoper.Core;
using SjonnieLoper.Core.Models;

namespace SjonieLoper.Services
{
    public interface IReservations
    {
        //IEnumerable<string> ReservationWhiskeyTypes();
        IEnumerable<Reservation> AllReservations();
        Reservation ReservationByCustomerId(int id);
        Reservation ReservationById(int id);
        IEnumerable<Reservation> ReservationByCustomerName(string name);
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
                new Reservation( 6, DateTime.Now, new Customer("Iris"), new Whiskey("Old Foo")),
                new Reservation( 5, DateTime.Now, new Customer("Vera"), new Whiskey("Jack Bar")),
                new Reservation( 4, DateTime.Now, new Customer("John"), new Whiskey("Golden Goose")),
                new Reservation( 3, DateTime.Now, new Customer("Erik"), new Whiskey("Monkey Handles")),
                new Reservation( 2, DateTime.Now, new Customer("Phoebe"), new Whiskey("Fizz Buzz")),
                new Reservation( 1, DateTime.Now, new Customer("Mohammed"), new Whiskey("Monkey Handles"))
            };
        }

        public IEnumerable<Reservation> AllReservations() => _reservations;

        public Reservation ReservationByCustomerId(int id) =>
            _reservations.FirstOrDefault(w => w.Id == id);

        public Reservation ReservationById(int id) =>
            _reservations.SingleOrDefault(r => r.Id == id);

        public IEnumerable<Reservation> ReservationByCustomerName(string name) =>
            _reservations.Where(r => r.User.UserName == name)
                .Select(r => r);

        public Reservation Update(Reservation updatedReservation)
        {
            var reservation = 
                _reservations.SingleOrDefault(r => r.Id == updatedReservation.Id);
            return reservation != null
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