using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Services.DataModels.Core.Models;
using SjonnieLoper.Services.DataModels.Services;

namespace SjonnieLoper.Services.DataModels.Pages.Reservations
{
    public class EditModel : PageModel
    {
        private readonly IReservations _reservationsDb;
        private readonly IWhiskeys _whiskeysDb;
        public IEnumerable<SelectListItem> RegisteredWhiskeys { get; set; }
        [BindProperty]
        public Reservation Reservation { get; set; }
        
        public EditModel(IReservations reservations,
                        IWhiskeys whiskeysDb,
                        IHtmlHelper htmlHelper)
        {
            _reservationsDb = reservations;
            _whiskeysDb = whiskeysDb;
            var allWhiskey = _whiskeysDb.AllWhiskeys();
            
            RegisteredWhiskeys = new SelectList(allWhiskey.ToList(), "Value","Name");
        }
        public IActionResult OnGet(int reservationId)
        {
            Reservation = _reservationsDb.ReservationById(reservationId);
            if (Reservation == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = "Created a new reservation.";
                _reservationsDb.Update(Reservation);
                _reservationsDb.Commit();
                //BUG: Redirect to details not showing. 
                return RedirectToPage("Reservations/Details", 
                    new { reservationId = Reservation.Id });
            }
            //TODO: Repopulate dropdown list values.
            return Page();
        }
    }
}