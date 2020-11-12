using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IWhiskeys _whiskeysDb;
        
        public Whiskey Product { get; set; }
        
        public EditModel(
            IWhiskeys whiskeysDb,
            IHtmlHelper htmlHelper)
        {
            _whiskeysDb = whiskeysDb;
        }
        public IActionResult OnGet(int whiskeyId)
        {
            Product = _whiskeysDb.WhiskeyById(whiskeyId);
            if (Product == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Created a new reservation.";
                _whiskeysDb.Update(Product);
                _whiskeysDb.Commit();
                /*
                return RedirectToPage("Reservations/Details", 
                    new { whiskeyId = Whiskey.WhiskeyId });
            */
                return RedirectToPage("Products/Details", 
                    new { whiskeyId = Product.WhiskeyId });
            }
            return Page();
        }
    }
}