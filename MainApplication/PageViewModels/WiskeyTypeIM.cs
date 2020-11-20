using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.PageViewModels
{
    public partial class CreateModel
    {
        public class InputModel
        {
            [DataType(DataType.Text)]
            [BindProperty]
            public string productTypeId { get; set; }

            [Display(Name = "Or add new Whiskey Type")]
            [WhiskeyTypeValidation(OtherProperty = "productTypeId", ErrorMessage = "Whiskey Type is required.")]
            [BindProperty]
            public string NewWhiskeyType { get; set; }
        }
    }
}