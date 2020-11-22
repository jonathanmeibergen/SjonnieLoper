using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly ISqlWhiskeys _whiskeysDb;
        private readonly ICacheWhiskey _whiskeyCache;
        
        public Whiskey Whiskey;
        [TempData] public string Message { get; set; }

        public DetailsModel(ISqlWhiskeys whiskeys,
            ICacheWhiskey whiskeyCache)
        {
            _whiskeysDb = whiskeys;
            _whiskeyCache = whiskeyCache;
        }

        public async Task<IActionResult> OnGet(int productId)
        {
            // TODO: Tie in get from cache an coalesce local Whiskey to db.
            var a = _whiskeyCache.GetById(productId);
            Whiskey = await _whiskeysDb.GetById(productId);
            if (Whiskey == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Created a new whiskey.";
                await _whiskeysDb.Update(Whiskey);
                await _whiskeysDb.Commit();
                //BUG: Redirect to details not showing. 
                return RedirectToPage("DetailsWhiskey", 
                    new { productId = Whiskey.Id });
            }
            //TODO: Repopulate dropdown list values.
            return Page();
        } 
        }
    }