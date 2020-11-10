using SjonnieLoper.Core.Models;
using System;
using System.Collections.Generic;

namespace SjonnieLoper.Services
{
    public class MockReservation
    {
        private List<Reservation> _reservations;
        
        public MockReservation()
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
    }
}