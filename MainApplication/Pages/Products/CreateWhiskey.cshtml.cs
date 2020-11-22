using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Components;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public partial class CreateModel : PageModel
    {
        private readonly ISqlWhiskeys _whiskeysDb;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICacheWhiskey _whiskeyCache;

        [BindProperty(SupportsGet = true)]
        public IEnumerable<SelectListItem> RegisteredWhiskeyTypes { get; set; }

        [BindProperty]
        public IFormFile ImageUpload { get; set; }
        
        [Display(Name = "Whiskey type")]
        [BindProperty]
        public string WhiskeyType { get; set; }
        [BindProperty] public Whiskey Whiskey { get; set; }
        public PageViewModels.InputModel InputModel { get; set; }

        public CreateModel(ISqlWhiskeys whiskeysDb,
            IWebHostEnvironment webHostEnvironment,
            ICacheWhiskey whiskeyCache)
        {
            _whiskeysDb = whiskeysDb;
            _webHostEnvironment = webHostEnvironment;
            _whiskeyCache = whiskeyCache;
        }



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
                //TODO: Resolve race condition redis vs sql unit of work.
            }
            return RedirectToPage("DetailsWhiskey",
                new { productId = Whiskey.Id });
        }
    }
}