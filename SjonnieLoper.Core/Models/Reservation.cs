using System;

namespace SjonnieLoper.Core.Models
{
    public abstract class Reservation
    {

        public int Id { get; set; }
        public DateTime Orderdate { get; set; }
        public string Whiskey { get; set; }
        //TODO: Choose single of two derived classes.
        public Customer CustomerOrder { get; set; }
        
        public Reservation(int id, DateTime time, Customer customer, string whiskey)
        {
            Id = id;
            Orderdate = time;
            CustomerOrder = customer;
            Whiskey = whiskey;
        }

        public Reservation()
        {
            
        }

    }
}