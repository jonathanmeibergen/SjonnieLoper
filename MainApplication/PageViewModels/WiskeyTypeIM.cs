using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.PageViewModels
{
        // .net core 3.1 wants a wrapper or inputmodel for custom validation (attribute) to work
        // otherwise the values inside the custom validation attribute are empty
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