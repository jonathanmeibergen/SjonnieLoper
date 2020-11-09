using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SjonnieLoper.Core.Models
{
    public class Whiskey
    {
        private string _whiskeyId;
        [ScaffoldColumn(false)] public string WhiskeyId 
        { 
            get => _whiskeyId; 
            set => _whiskeyId = value;
        }

        [Required] private string _name;
        
        public string Name
        {
            get => _name;
            set => _name = value;
        } 

        private int Age { get; }
        private string Origin { get; }
        [Required]
        private float AlcoholPercentage { get; }
        //[Required]
        private string ImagePath { get; }
        [Required] public WhiskeyType WhiskeyType { get; }

        public Whiskey(int whiskeyId, string name, int age, string origin, float alcoholPercentage, string imagePath, WhiskeyType whiskeyType)
        {
            WhiskeyId = Convert.ToString(whiskeyId);
            _whiskeyId = name;
            Age = age;
            Origin = origin;
            AlcoholPercentage = alcoholPercentage;
            ImagePath = imagePath;
            WhiskeyType = whiskeyType;    
        }

        // Development constructor for Mock_reservations.
        public Whiskey(string name)
        {
            Name = name;
        }

        public Whiskey(Whiskey product)
        {
            WhiskeyId = product.WhiskeyId;
            _whiskeyId = product.Name;
            Age = product.Age;
            Origin = product.Origin;
            AlcoholPercentage = product.AlcoholPercentage;
            ImagePath = product.ImagePath;
            WhiskeyType = product.WhiskeyType;    
        }
        
        public Whiskey()
        {
        }
        
    }
}
