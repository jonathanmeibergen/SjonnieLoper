using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SjonnieLoper.Core
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Orderdate { get; set; }
        public Whiskey whiskey { get; set; }
        public Customer Customer { get; set; }

        public Reservation(int id, DateTime orderdate, Customer customer)
        {
            Id = id;
            Orderdate = orderdate;
            Customer = customer;
        }
    }
}