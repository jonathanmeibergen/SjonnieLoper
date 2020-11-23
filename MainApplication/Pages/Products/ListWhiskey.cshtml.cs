using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;
using StackExchange.Redis;

namespace SjonnieLoper.Pages.Products
{
    public class ListModel : PageModel
    {
        private readonly ISqlWhiskeys _whiskeyDb;
        private readonly ICacheWhiskey _whiskeyCache;
        
        public ListModel(ISqlWhiskeys whiskeys,
            ICacheWhiskey whiskeyCache)
        {
            _whiskeyDb = whiskeys;
            _whiskeyCache = whiskeyCache;
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
                ? await _whiskeyDb.GetAll()
                : await _whiskeyDb.GetByName(SearchValue);
            if (String.IsNullOrEmpty(SearchValue))
            {
                RetrievedWhiskeys = await _whiskeyCache.GetAll();
                if (RetrievedWhiskeys is null)
                {
                    RetrievedWhiskeys = await _whiskeyDb.GetAll();
                    await _whiskeyCache.UpdateWhiskeySet(RetrievedWhiskeys);
                }
            }
            else
            {
                RetrievedWhiskeys = await (_whiskeyCache.GetByName(SearchValue) 
                                           ?? _whiskeyDb.GetByName(SearchValue));
            }
            
            return Page();
        }
        
        public IActionResult OnPost()
        {
            return RedirectToPage();
        }
    }
}