using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonieLoper.Services;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Pages.Products
{
    public class ListModel : PageModel
    {
        private readonly IWhiskeys _whiskeyDb;

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