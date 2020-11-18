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
        public async Task<IActionResult> OnGet(int whiskeyId)
        {
            Product = await _whiskeysDb.WhiskeyById(whiskeyId);
            if (Product == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Created a new reservation.";
                await _whiskeysDb.Update(Product);
                await _whiskeysDb.Commit();
                return RedirectToPage("Products/Details", 
                    new { whiskeyId = Product.Id });
            }
            return Page();
        }
    }
}