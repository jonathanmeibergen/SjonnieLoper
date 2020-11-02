using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Whiskey
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Origin { get; set; }
        public float AlcoholPercentage { get; set; }
        public int MyProperty { get; set; }



        //naam, de leeftijd, het productiegebied, het alcoholpercentage, en de soort
    }

    public enum WhiskeyType
    {
        Irish,
        Scotch,
        Japanese,
        Canadian,


    }
}
