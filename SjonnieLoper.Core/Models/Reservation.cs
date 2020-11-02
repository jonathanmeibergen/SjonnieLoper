using System;
using System.Collections.Generic;
using System.Text;

namespace SjonnieLoper.Core
{
    class Reservation
    {
        public int Id { get; set; }
        public DateTime Orderdate { get; set; }
        public Customer Customer { get; set; }
    }
}