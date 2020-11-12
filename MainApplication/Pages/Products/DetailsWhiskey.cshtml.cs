using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
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

        public IActionResult OnGet(int Id)
        {
            Whiskey = _IWhiskeys.WhiskeyById(Id);
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
                    new { reservationId = Whiskey.Id });
            }
            //TODO: Repopulate dropdown list values.
            return Page();
        } 
        }
    }