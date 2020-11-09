using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Services.DataModels.Core.Models;
using SjonnieLoper.Services.DataModels.Pages.Products.ViewModels;
using SjonnieLoper.Services.DataModels.Services;

namespace SjonnieLoper.Services.DataModels.Pages.Products
{
    public class ListModel : PageModel
    {
        private readonly IWhiskeys _whiskeyDb;
        public ProductViewModel Whiskey;
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