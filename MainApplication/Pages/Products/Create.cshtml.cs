using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Core;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Products
{
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public CreateModel(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public void OnGet()
        {
            //_userManager.GetClaimsAsync()
        }
    }
}