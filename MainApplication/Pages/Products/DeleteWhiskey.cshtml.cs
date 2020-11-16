using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IWhiskeys _whiskeyDb;
        public Whiskey Whiskey { get; set; }

        public DeleteModel(IWhiskeys whiskey)
        {
            _whiskeyDb = whiskey;
        }

        public IActionResult OnGet(int productId)
        {
            Whiskey = _whiskeyDb.WhiskeyById(productId);
            if (Whiskey == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(int productId)
        {
            Whiskey = _whiskeyDb.Delete(productId);
            _whiskeyDb.Commit();
            if (Whiskey == null)
            {
                return RedirectToPage("./NotFound");
            }

            return RedirectToPage("./ListWhiskey");
        }
    }
}