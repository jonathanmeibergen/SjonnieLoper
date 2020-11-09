using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SjonnieLoper.Core.Models
{
    public class Whiskey
    {
        [ScaffoldColumn(false)]
        [DisplayName("Whiskey #")]
        public int WhiskeyId { get; set; }
        [Required]
        [DisplayName("Name ")]
        public string Name { get; set; }
        [DisplayName("Age ")]
        public int Age { get; }
        [DisplayName("Origin ")]
        public string Origin { get; }
        [Required]
        [DisplayName("Percentage of alcohol")]
        public float AlcoholPercentage { get; }
        //[Required]
        public string ImagePath { get; }
        [Required]
        [DisplayName("Type of whiskey ")]
        public WhiskeyType WhiskeyType { get; }

        public Whiskey(int whiskeyId, string name, int age, string origin, float alcoholPercentage, string imagePath, WhiskeyType whiskeyType)
        {
            WhiskeyId = whiskeyId;
            Name = name;
            Age = age;
            Origin = origin;
            AlcoholPercentage = alcoholPercentage;
            ImagePath = imagePath;
            WhiskeyType = whiskeyType;    
        }

        // Development constructor for Mock_reservations.
        public Whiskey(string name)
        {
            Name = Name;
        }
        
        public Whiskey()
        {
        }
        
    }
}
