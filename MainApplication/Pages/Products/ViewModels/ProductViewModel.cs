using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Products.ViewModels
{
    public class ProductViewModel : Whiskey 
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
            public string WhiskeyType { get; }

            public ProductViewModel(int whiskeyId, string name, int age, string origin, float alcoholPercentage)
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
            public ProductViewModel(string name)
            {
                Name = Name;
            }
        
            public ProductViewModel()
            {
            }
        
    }
}