using System.Threading.Tasks;
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
        public async Task<IActionResult> OnGet(int reservationId)
        {
            Reservation = await _reservationsDb.ReservationById(reservationId);
            if (Reservation == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(int reservationId)
        {
            await _reservationsDb.Delete(reservationId);
            await _reservationsDb.Commit();
            if (Reservation == null)
            {
                return RedirectToPage("./NotFound");
            }
            return RedirectToPage("./List");
        }
    }
}