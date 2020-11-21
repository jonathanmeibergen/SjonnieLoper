using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Store
{
    public class BrowseProducts : PageModel
    {
        private readonly ISqlWhiskeys _whiskeyDb;
        
        public BrowseProducts(ISqlWhiskeys whiskeys)
        {
            _whiskeyDb = whiskeys;
        }

        [BindProperty(SupportsGet = true)]
        public string ProductType { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }
        //[BindProperty] 
        [BindProperty]
        public IEnumerable<Whiskey> RetrievedWhiskeys { get; set; }
        
        public async Task<IActionResult>  OnGet()
        {
            RetrievedWhiskeys = String.IsNullOrEmpty(SearchValue)
                ? await _whiskeyDb.GetAll()
                : await _whiskeyDb.GetByName(SearchValue);
            return Page();
        }
        
        public IActionResult OnPost()
        {
            return RedirectToPage();
        }
    }
}