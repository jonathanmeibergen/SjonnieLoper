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

        public IEnumerable<SelectListItem> RegisteredWhiskeyTypes { get; set; }

        [BindProperty]
        public IFormFile ImageUpload { get; set; }

        [BindProperty]
        public string NewWhiskeyType { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Whiskey Type is required.")]
        public string WhiskeyType { get; set; }

        [BindProperty]
        public int productTypeId { get; set; } = 0;
        [BindProperty] public Whiskey Whiskey { get; set; }


        public CreateModel(IWhiskeys whiskeysDb, IWebHostEnvironment webHostEnvironment)
        {
            _whiskeysDb = whiskeysDb;
            _webHostEnvironment = webHostEnvironment;
        }
        
        public IActionResult OnGet()
        {
            Whiskey = new Whiskey();
            //RegisteredWhiskeyTypes = _whiskeysDb.
            RegisteredWhiskeyTypes = _whiskeysDb.GetWhiskeyTypes().GetWhiskeyTypesSelectList();
            
            /*RegisteredWhiskeyTypes = _whiskeysDb
                .AllWhiskeys()
                .GroupBy(w => w.WhiskeyType)
                .Select(t => t.Key)
                .GetWhiskeyTypes();
            */
            return Page();
        }
        
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                RegisteredWhiskeyTypes = _whiskeysDb.GetWhiskeyTypes().GetWhiskeyTypesSelectList();
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

                    Whiskey.ImagePath = Path.Combine("uploads",
                                                     Whiskey.Id.ToString(),
                                                     Path.GetFileName(filePath));
                }
                TempData["Message"] = "Added a new Whiskey product";

                if (NewWhiskeyType == null && productTypeId == 0)
                    Page();

                Whiskey.WhiskeyType = NewWhiskeyType == null ? 
                    _whiskeysDb.GetWhiskeyTypeById(productTypeId) : _whiskeysDb.CreateWhiskeyType(NewWhiskeyType);

                _whiskeysDb.Create(Whiskey);
                _whiskeysDb.Commit();
            }
            return RedirectToPage("DetailsWhiskey",
                new { productId = Whiskey.Id });
        }

    }
}