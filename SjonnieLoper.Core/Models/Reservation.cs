using System;
using System.ComponentModel.DataAnnotations;

namespace SjonnieLoper.Core.Models
{
    public class Reservation
    {

        public int Id { get; set; }
        public DateTime Orderdate { get; set; }
        [Required]
        public Whiskey Whiskey { get; set; }
        //TODO: Choose single of two derived classes.
        public ApplicationUser User { get; set; }
        public Customer CustomerOrder { get; set; }
        
        public Reservation(int id, DateTime time, Customer customer, Whiskey whiskey)
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