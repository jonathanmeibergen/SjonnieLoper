using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly ISqlWhiskeys _whiskeyDb;
        public Whiskey Whiskey { get; set; }

        public DeleteModel(ISqlWhiskeys whiskey)
        {
            _whiskeyDb = whiskey;
        }

        public async Task<IActionResult> OnGet(int productId)
        {
            Whiskey = await _whiskeyDb.GetById(productId);
            if (Whiskey == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int productId)
        {
            Whiskey = await _whiskeyDb.Delete(productId);
            if (Whiskey == null)
            {
                return RedirectToPage("./NotFound");
            }
            await _whiskeyDb.Commit();
            return RedirectToPage("./ListWhiskey");
        }
    }
}