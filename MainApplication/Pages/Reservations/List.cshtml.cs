using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonieLoper.Services;
using SjonnieLoper.Core;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Pages.Reservations
{
    public class ListModel : PageModel
    {
        private readonly IReservations _reservationsDb;

        public ListModel(IReservations reservations)
        {
            _reservationsDb = reservations;
        }

        [BindProperty] 
        public IEnumerable<Reservation> Reservations => _reservationsDb.AllReservations();
        
        public void OnGet()
        {
            
        }

    }
}