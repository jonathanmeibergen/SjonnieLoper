using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SjonnieLoper.Core.Models
{
    public class Whiskey
    {
        [Key]
        [Required]
        [Display(Name="Id of whiskey ")]
        public int Id { get; set; }

        [Required] 
        [Display(Name="Whiskey name ")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Age in whole years ")]
        public int Age { get; set; }
        
        [Required]
        [Display(Name="Origin of whiskey ")]
        public string Origin { get; set; }
        
        [Required]
        [Display(Name="Alcohol percentage of whiskey ")]
        public float AlcoholPercentage { get; set; }
        
        public string ImagePath { get; set; }
        
        public virtual WhiskeyType WhiskeyType { get; set; }

        public Whiskey(int id, string name, int age, string origin, float alcoholPercentage, string imagePath, WhiskeyType whiskeyType)
        {
            Id = id;
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
            Name = name;
        }

        public Whiskey(Whiskey product)
        {
            Id = product.Id;
            Name = product.Name;
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
