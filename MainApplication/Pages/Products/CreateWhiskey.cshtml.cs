using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IWhiskeys _whiskeysDb;
        
        public IEnumerable<SelectListItem> RegisteredWhiskeyTypes { get; set; }
        private IEnumerable<WhiskeyType> whiskeyTypes { get; set; }

        [BindProperty(SupportsGet = true)]
        public int productAddedID { get; set; }
        [BindProperty] public Whiskey Whiskey { get; set; }


        public CreateModel(IWhiskeys whiskeysDb)
        {
            _whiskeysDb = whiskeysDb;
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
                //TODO: Repopulate dropdown list.
                return Page();
            }
            else
            {
                TempData["Message"] = "Added a new Whiskey product";
                _whiskeysDb.Create(Whiskey);
            }
            return RedirectToPage("Reservations/DetailsWhiskey",
                new {reservationId = Whiskey.Id });
        } 
    }
}