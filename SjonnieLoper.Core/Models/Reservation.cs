using System;

namespace SjonnieLoper.Core.Models
{
    public class Reservation
    {

        public int Id { get; set; }
        public DateTime Orderdate { get; set; }
        public Whiskey Whiskey { get; set; }
        public ApplicationUser User { get; set; }
        public Customer CustomerOrder { get; set; }
        
        public Reservation(int id,DateTime time, Customer customer)
        {
            Id = id;
            Orderdate = time;
            CustomerOrder = customer;
        }

    }
}