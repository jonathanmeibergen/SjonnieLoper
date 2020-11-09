using System;
using System.ComponentModel.DataAnnotations;
using SjonnieLoper.Core.Models;

namespace SjonieLoper.Core.Models
{
    public class Reservation 
    {

        public int Id { get; set; }
        public DateTime Orderdate { get; set; }
        public string Whiskey { get; set; }
        [ScaffoldColumn(false)]
        public Customer Customer { get; set; }

        public virtual string ClientName
        
        {
            get => Customer.UserName;
            set => Customer.UserName = value;
            
        }
        public Reservation(int id, DateTime time, Customer customer, string whiskey)
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
            customer = @base.customer;
            Whiskey = @base.Whiskey;
        }
        
        public Reservation()
        {
            
        }

    }
}