using System.ComponentModel.DataAnnotations;

namespace SjonnieLoper.Core.Models
{
    public class Whiskey
    {
        public int WhiskeyId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; }
        public string Origin { get; }
        [Required]
        public float AlcoholPercentage { get; }
        //[Required]
        public string ImagePath { get; }
        [Required]
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
