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
            // TODO: Specify lifetime expiry.
            Whiskey = await _whiskeyCache.GetById(productId) ;
            if (Whiskey is null)
            {
                Whiskey = await _whiskeysDb.GetById(productId);
                if(Whiskey is null)
                    return RedirectToPage("./NotFound");
                await _whiskeyCache.Create(Whiskey);
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Created a new whiskey.";
                // In the context of redis 'Update' does the same as 'Create',
                // Apply Update(create) here to mirror EF binding status service side.
                _whiskeyCache.Update(Whiskey);
                
                _whiskeysDb.Update(Whiskey);
                await _whiskeysDb.Commit();
                return RedirectToPage("DetailsWhiskey", 
                    new { productId = Whiskey.Id });
            }
            return Page();
        } 
        }
    }