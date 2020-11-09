using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SjonnieLoper.Core.Models;

namespace SjonieLoper.Core.Models
{
    public class Reservation 
    {

        public virtual int Id { get; set; }
        public virtual DateTime Orderdate { get; set; }
        
        public virtual Whiskey Whiskey { get; set; }
        [ScaffoldColumn(false)]
        public virtual Customer Customer { get; set; }
        [DisplayName("Name of client ")]
        public virtual string ClientName
        
        {
            get => Customer.UserName;
            set => Customer.UserName = value;
            
        }
        public Reservation(int id, DateTime time, Customer customer, Whiskey whiskey)
        {
            Id = id;
            Orderdate = time;
            customer = customer;
            Whiskey = whiskey;
        }

        public Reservation(Reservation @base)
        {
            Id = @base.Id;
            Orderdate = @base.Orderdate;
            Customer = @base.Customer;
            Whiskey = @base.Whiskey;
        }
        
        public Reservation()
        {
            
        }

    }
}