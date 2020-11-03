﻿using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SjonnieLoper.Core
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Orderdate { get; set; }
        public Whiskey Whiskey { get; set; }
        public ApplicationUser User { get; set; }
    }
}