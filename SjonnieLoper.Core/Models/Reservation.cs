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
        //TODO: Retrieve UserName from ApplicationUser
        public ApplicationUser Customer { get; set; }        
        public Reservation(int id, DateTime time, ApplicationUser customer, Whiskey whiskey)
        {
            Id = id;
            Orderdate = time;
            Customer = customer;
            Whiskey = whiskey;
        }

        public Reservation()
        {
            
        }

    }
}