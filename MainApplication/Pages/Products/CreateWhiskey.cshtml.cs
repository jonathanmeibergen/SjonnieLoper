using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IWhiskeys _whiskeysDb;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public InputModel inputModel { get; set; }

        public CreateModel(IWhiskeys whiskeysDb, IWebHostEnvironment webHostEnvironment)
        {
            _whiskeysDb = whiskeysDb;
            _webHostEnvironment = webHostEnvironment;
        }

            [BindProperty(SupportsGet = true)]
            public IEnumerable<SelectListItem> RegisteredWhiskeyTypes { get; set; }

            [BindProperty]
            public IFormFile ImageUpload { get; set; }
            
            [Display(Name = "Whiskey type")]
            [BindProperty]
            public string WhiskeyType { get; set; }
            [BindProperty] public Whiskey Whiskey { get; set; }

        // .net core 3.1 wants a wrapper or inputmodel for custom validation (attribute) to work
        // otherwise the values inside the custom validation attribute are empty
        public class InputModel
        {
            [DataType(DataType.Text)]
            [BindProperty]
            public string productTypeId { get; set; }

            [Display(Name = "Or add new Whiskey Type")]
            [WhiskeyTypeValidationAttribute(OtherProperty = "productTypeId", ErrorMessage = "Whiskey Type is required.")]
            [BindProperty]
            public string NewWhiskeyType { get; set; }
        }

        public IActionResult OnGet()
        {
            Whiskey = new Whiskey();
            RegisteredWhiskeyTypes = _whiskeysDb.GetTypes().GetWhiskeyTypesSelectList();
            return Page();
        }
        
        public IActionResult OnPost(InputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                RegisteredWhiskeyTypes = _whiskeysDb.GetTypes().GetWhiskeyTypesSelectList();
                return Page();
            }
            else
            {
                if (ImageUpload != null)
                {
                    var directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath,
                                                     "wwwroot",
                                                     "uploads",
                                                     Whiskey.Id.ToString());
                    var filePath = Path.Combine(directoryPath,
                                                Path.GetFileName(ImageUpload.FileName));

                    Directory.CreateDirectory(directoryPath);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        if (ImageUpload.ContentType.ToString().Contains("image"))
                            ImageUpload.CopyTo(fileStream);
                    }

                    Whiskey.ImagePath = Path.Combine(@"\uploads",
                                                     Whiskey.Id.ToString(),
                                                     Path.GetFileName(filePath));
                }
                TempData["Message"] = "Added a new Whiskey product";

                //TODO check if this redirect is necessary
                if (inputModel.NewWhiskeyType == null && Int32.Parse(inputModel.productTypeId) == 0)
                    Page();

                Whiskey.WhiskeyType = inputModel.NewWhiskeyType == null ? 
                    _whiskeysDb.GetTypeById(Int32.Parse(inputModel.productTypeId)) : _whiskeysDb.CreateType(inputModel.NewWhiskeyType);

                _whiskeysDb.Create(Whiskey);
                _whiskeysDb.Commit();
            }
            return RedirectToPage("DetailsWhiskey",
                new { productId = Whiskey.Id });
        }
    }
}