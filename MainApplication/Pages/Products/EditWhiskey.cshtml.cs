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
        private readonly ISqlWhiskeys _whiskeysDb;
        
        public Whiskey Product { get; set; }
        
        public EditModel(
            ISqlWhiskeys whiskeysDb,
            IHtmlHelper htmlHelper)
        {
            _whiskeysDb = whiskeysDb;
        }
        public async Task<IActionResult> OnGet(int whiskeyId)
        {
            Product = await _whiskeysDb.GetById(whiskeyId);
            if (Product == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Created a new reservation.";
                _whiskeysDb.Update(Product);
                await _whiskeysDb.Commit(Product.Id);
                return RedirectToPage("Products/Details", 
                    new { whiskeyId = Product.Id });
            }
            return Page();
        }
    }
}