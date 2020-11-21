using System;
using System.Collections.Generic;
using System.Text;

namespace SjonnieLoper.Core.Models
{
    public class Storage
    {
        public int Id { get; set; }
        public Whiskey whiskey { get; set; }
        public int Amount { get; set; }
    }
}
