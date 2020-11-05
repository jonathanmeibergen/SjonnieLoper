using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Services;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Pages.Reservations
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