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
            this._reservationsDb = reservations;
        }
        [BindProperty]
        public IEnumerable<Reservation> Reservations { get; set; }
        
        public void OnGet()
        {
            this.Reservations = _reservationsDb.AllReservations();
        }

    }
}