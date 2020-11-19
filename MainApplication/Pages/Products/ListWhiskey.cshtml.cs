using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public class ListModel : PageModel
    {
        private readonly IWhiskeys _whiskeyDb;
        
        public ListModel(IWhiskeys whiskeys)
        {
            _whiskeyDb = whiskeys;
        }
        public SelectList ResTypes { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ProductType { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }
        //[BindProperty] 
        [BindProperty]
        public IEnumerable<Whiskey> RetrievedWhiskeys { get; set; }
        
        public async Task<IActionResult> OnGet()
        {
            RetrievedWhiskeys = String.IsNullOrEmpty(SearchValue)
                ? await _whiskeyDb.AllWhiskeys()
                : await _whiskeyDb.WhiskeyByName(SearchValue);
            return Page();
        }
        
        public IActionResult OnPost()
        {
            return RedirectToPage();
        }
    }
}