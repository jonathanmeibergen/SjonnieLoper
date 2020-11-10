using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IWhiskeys _whiskeysDb;
        public IEnumerable<SelectListItem> RegisteredWhiskeyTypes { get; set; }
        [BindProperty(SupportsGet = true)]
        public int productAddedID { get; set; }
        [BindProperty] public Whiskey Whiskey { get; set; }

        public CreateModel(IWhiskeys whiskeysDb)
        {
            _whiskeysDb = whiskeysDb;
        }
        public void OnGet()
        {
            //RegisteredWhiskeyTypes = _whiskeysDb.WhiskeyCategories()

        }
    }
}