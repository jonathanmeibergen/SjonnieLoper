using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;
using SjonnieLoper.Services.DataModels.Services;

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

        [BindProperty]
        public IEnumerable<Whiskey> RetrievedWhiskeys
            => _whiskeyDb.AllWhiskeys();
        
        public void OnGet()
        {

        }
    }
}