using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public partial class CreateModel : PageModel
    {
        private readonly IWhiskeys _whiskeysDb;
        private readonly IWebHostEnvironment _webHostEnvironment;

        // .net core 3.1 wants a wrapper or inputmodel for custom validation (attribute) to work
        // otherwise the values inside the custom validation attribute are empty
        public PageViewModels.InputModel InputModel { get; set; }

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


        public IActionResult OnGet()
        {
            Whiskey = new Whiskey();
            RegisteredWhiskeyTypes = _whiskeysDb.GetAllTypes().Result.GetWhiskeyTypesSelectList();
            return Page();
        }
        
        public async Task<IActionResult> OnPost(PageViewModels.InputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                RegisteredWhiskeyTypes = _whiskeysDb.GetAllTypes().Result.GetWhiskeyTypesSelectList();
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

                Whiskey.WhiskeyType = inputModel.NewWhiskeyType == null 
                    ? await _whiskeysDb.GetTypeById(Int32.Parse(inputModel.productTypeId)) 
                    : await _whiskeysDb.CreateType(inputModel.NewWhiskeyType);

                await _whiskeysDb.Create(Whiskey);
                await _whiskeysDb.Commit();
            }
            return RedirectToPage("DetailsWhiskey",
                new { productId = Whiskey.Id });
        }
    }
}