using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Reservations
{
    public class DeleteModel : PageModel
    {
        private readonly IReservations _reservationsDb;
        public Reservation Reservation { get; set; } 
        
        public DeleteModel(IReservations reservations)
        {
            _reservationsDb = reservations;
        }
        public IActionResult OnGet(int reservationId)
        {
            Reservation = _reservationsDb.ReservationById(reservationId);
            if (Reservation == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int reservationId)
        {
            _reservationsDb.Delete(reservationId);
            _reservationsDb.Commit();
            if (Reservation == null)
            {
                return RedirectToPage("./NotFound");
            }
            return RedirectToPage("./List");
        }
    }
}