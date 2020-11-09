using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Services.DataModels.Core.Models;
using SjonnieLoper.Services.DataModels.Services;

namespace SjonnieLoper.Services.DataModels.Pages.Reservations
{
    public class DetailsModel : PageModel
    {
        private readonly IReservations _reservationsDb;
        public Reservation Reservation;
        [TempData]
        public string Message { get; set; }

        public DetailsModel(IReservations reservations)
        {
            _reservationsDb = reservations;
        }
        public IActionResult OnGet(int reservationId)
        {
            Reservation = _reservationsDb.ReservationById(reservationId);
            
            if (Reservation == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
    }
}