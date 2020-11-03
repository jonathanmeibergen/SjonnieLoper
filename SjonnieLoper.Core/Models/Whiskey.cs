using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SjonnieLoper.Core
{
    public class Whiskey
    {
        public int WhiskeyId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Origin { get; set; }
        public float AlcoholPercentage { get; set; }
        public string ImagePath { get; set; }
        public WhiskeyType WhiskeyType { get; set; }
    }
}
