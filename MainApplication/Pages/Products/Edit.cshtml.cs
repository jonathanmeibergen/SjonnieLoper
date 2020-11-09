using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonieLoper.Services;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Pages.ViewModels;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IReservations _reservationsDb;
        private readonly IWhiskeys _whiskeysDb;
        
        public WhiskeyViewModel Whiskey { get; set; }

        public EditModel(IReservations reservations,
            IWhiskeys whiskeysDb,
            IHtmlHelper htmlHelper)
        {
            _reservationsDb = reservations;
            _whiskeysDb = whiskeysDb;
        }
        public IActionResult OnGet(int whiskeyId)
        {
            Whiskey = new WhiskeyViewModel(_whiskeysDb.WhiskeyById(whiskeyId));
            if (Whiskey == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Created a new reservation.";
                _whiskeysDb.Update(new Whiskey(Whiskey));
                _whiskeysDb.Commit();
                /*
                return RedirectToPage("Reservations/Details", 
                    new { whiskeyId = Whiskey.WhiskeyId });
            */
                return RedirectToPage("Products/Details", 
                    new { whiskeyId = Whiskey.WhiskeyId });
            }
            return Page();
        }
    }
}