using System;
using System.Collections.Generic;
using System.Linq;
using SjonnieLoper.Core;
using SjonnieLoper.Core.Models;

namespace SjonieLoper.Services
{
    public interface IReservations
    {
        IEnumerable<Reservation> AllReservations();
        Reservation ReservationCustomerId(int id);
    }

    public class Mock_Reservations : IReservations
    {
        private IEnumerable<Reservation> _reservations;
        
        public Mock_Reservations()
        {
            _reservations = new List<Reservation>()
            {
                new Reservation( 6, DateTime.Now, (new Customer("Iris"))),
                new Reservation( 5, DateTime.Now, (new Customer("Vera"))),
                new Reservation( 4, DateTime.Now, (new Customer("John"))),
                new Reservation( 3, DateTime.Now, (new Customer("Erik"))),
                new Reservation( 2, DateTime.Now, (new Customer("Phoebe"))),
                new Reservation( 1, DateTime.Now, (new Customer("Mohammed")))
            };
        }

        public IEnumerable<Reservation> AllReservations()
        {
            return _reservations;
        }

        public Reservation ReservationCustomerId(int id)
        {
            return _reservations.FirstOrDefault(w => w.Id == id);
        }
    }
}