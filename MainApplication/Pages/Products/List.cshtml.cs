using System;
using System.Collections.Generic;
using System.Linq;
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
        public Whiskey Whiskey;
        
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
        
        public void OnGet()
        {
            RetrievedWhiskeys = String.IsNullOrEmpty(SearchValue)
                ? _whiskeyDb.AllWhiskeys()
                : _whiskeyDb.WhiskeyByName(SearchValue);
        }
    }
}