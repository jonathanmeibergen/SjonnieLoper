using System;
using System.Collections.Generic;

namespace SjonnieLoper.Core.Models
{
    public interface IReservations
    {
        IEnumerable<Reservation> AllReservations();
        Reservation ReservationCustomerId(int id);
    }

    public class Mock_Reservations
    {
        private IEnumerable<Reservation> _reservations;
        
        public Mock_Reservations()
        {
            _reservations = new List<Reservation>()
            {
                //new Reservation( 5, DateTime.Now, (new Customer("Vera")))
            };
        }
        
    }
}