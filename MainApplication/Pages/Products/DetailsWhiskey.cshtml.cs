using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IWhiskeys _whiskeys;
        public Whiskey Whiskey;
        [TempData] public string Message { get; set; }

        public DetailsModel(IWhiskeys whiskeys)
        {
            _whiskeys = whiskeys;
        }

        public IActionResult OnGet(int productId)
        {
            Whiskey = _whiskeys.GetById(productId);
            if (Whiskey == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Created a new whiskey.";
                _whiskeys.Update(Whiskey);
                _whiskeys.Commit();
                //BUG: Redirect to details not showing. 
                return RedirectToPage("DetailsWhiskey", 
                    new { productId = Whiskey.Id });
            }
            //TODO: Repopulate dropdown list values.
            return Page();
        } 
        }
    }