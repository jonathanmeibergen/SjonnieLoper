using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonieLoper.Core.Models;
using SjonieLoper.Services;
using SjonnieLoper.Pages.ViewModels;

namespace SjonnieLoper.Pages.Reservations
{
    public class DetailsModel : PageModel
    {
        private readonly IReservations _reservationsDb;
        [ScaffoldColumn(false)]
        
        public Reservation Reservation;
        
        public ReservationViewModel ReservationVM;
        [TempData]
        public string Message { get; set; }

        public DetailsModel(IReservations reservations)
        {
            _reservationsDb = reservations;
        }
        public IActionResult OnGet(int reservationId)
        {
            Reservation = _reservationsDb.ReservationById(reservationId);
            ReservationVM = new ReservationViewModel(Reservation);
            if (Reservation == null)
                return RedirectToPage("./NotFound");
            return Page();
        }
    }
}