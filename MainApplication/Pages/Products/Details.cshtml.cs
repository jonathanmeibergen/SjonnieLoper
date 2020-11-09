using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Services.DataModels.Core.Models;
using SjonnieLoper.Services.DataModels.Services;

namespace SjonnieLoper.Services.DataModels.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IWhiskeys _IWhiskeys;
        public Whiskey Whiskey;
        [TempData] public string Message { get; set; }

        public DetailsModel(IWhiskeys whiskeys)
        {
            _IWhiskeys = whiskeys;
        }

        public IActionResult OnGet(int whiskeyId)
        {
            Whiskey = _IWhiskeys.WhiskeyById(whiskeyId);
            if (Whiskey == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Created a new reservation.";
                _IWhiskeys.Update(Whiskey);
                _IWhiskeys.Commit();
                //BUG: Redirect to details not showing. 
                return RedirectToPage("Products/Details", 
                    new { reservationId = Whiskey.WhiskeyId });
            }
            //TODO: Repopulate dropdown list values.
            return Page();
        } 
        }
    }