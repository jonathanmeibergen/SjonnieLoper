using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Core;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Pages.Reservations
{
    public class ListModel : PageModel
    {
        private IReservations _reservationsDb;
        public IEnumerable<Reservation> Reservations { get; set; }

        public ListModel(IReservations reservations)
        {
            this._reservationsDb = reservations;
        }
        
        public void OnGet()
        {
            this.Reservations = _reservationsDb.AllReservations();
        }

    }
}