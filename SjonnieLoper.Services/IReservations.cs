using System;
using System.Collections.Generic;
using System.Linq;

namespace SjonnieLoper.Core.Models
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
                new Reservation( 5, DateTime.Now, (new Customer("Vera")))
            };
        }

        public IEnumerable<Reservation> AllReservations()
        {
            return _reservations;
        }

        public Reservation ReservationCustomerId(int id)
        {
            return _reservations.FirstOrDefault(w =. whiskey.)
        }
    }
}