using System;
using System.Collections.Generic;
using System.Linq;
using SjonnieLoper.Core;
using SjonnieLoper.Core.Models;

namespace SjonieLoper.Services
{
    public interface IReservations
    {
        IEnumerable<string> ReservationWhiskeyTypes();
        IEnumerable<Reservation> AllReservations();
        Reservation ReservationCustomerId(int id);
        IEnumerable<Reservation> ReservationsCustomerName(string name);
    }

    public class Mock_Reservations : IReservations
    {
        private IEnumerable<Reservation> _reservations;
        
        public Mock_Reservations()
        {
            _reservations = new List<Reservation>()
            {
                new Reservation( 6, DateTime.Now, new Customer("Iris")),
                new Reservation( 5, DateTime.Now, new Customer("Vera")),
                new Reservation( 4, DateTime.Now, new Customer("John")),
                new Reservation( 3, DateTime.Now, new Customer("Erik")),
                new Reservation( 2, DateTime.Now, new Customer("Phoebe")),
                new Reservation( 1, DateTime.Now, new Customer("Mohammed"))
            };
        }
        
        /*public IEnumerable<string> ReservationWhiskeyTypes => 
            _reservations.Select(r => r.Whiskey.WhiskeyType.Name)
            .Distinct();*/

        // TODO: Change double null check and/or type accessors.
        public IEnumerable<string> ReservationWhiskeyTypes() => 
            _reservations.Where(o => o.Whiskey != null 
                                     && !string.IsNullOrEmpty(o.Whiskey.WhiskeyType.Name)).GroupBy(s => s.Whiskey.WhiskeyType)
                                       // .Distinct()
                                       // .Where(t => t != null)
                                        .Select(productType => productType.Key.Name);

        public IEnumerable<Reservation> AllReservations() => _reservations;

        public Reservation ReservationCustomerId(int id) =>
            _reservations.FirstOrDefault(w => w.Id == id);

        public IEnumerable<Reservation> ReservationsCustomerName(string name) =>
                _reservations.Select(r => r)
                .Where(entry => entry.CustomerOrder.UserName == name)
                .Select(x => x);
    }
}