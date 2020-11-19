using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Reservations
{
    public class EditModel : PageModel
    {
        private readonly IReservations _reservationsDb;
        private readonly IWhiskeys _whiskeys;
        public IEnumerable<SelectListItem> RegisteredWhiskeys { get; set; }
        [BindProperty(SupportsGet = true)]
        public int productAddedID { get; set; }
        [BindProperty]
        public Reservation Reservation { get; set; }

        public EditModel(IReservations reservations,
                        IWhiskeys whiskeysDb)
        {
            _reservationsDb = reservations;
            _whiskeys = whiskeysDb;

        }
        public IActionResult OnGet(int reservationId)
        {
            RegisteredWhiskeys = _whiskeys
                .GetAll()
                .GetWhiskeysSelectList();
            Reservation = _reservationsDb.ReservationById(reservationId);
            if (Reservation == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Reservation.Product = new Whiskey(_whiskeys.GetById(productAddedID));
                TempData["Message"] = "Created a new reservation.";
                _reservationsDb.Update(Reservation);
                _reservationsDb.Commit();
                return RedirectToPage("./Details", 
                    new { reservationId = Reservation.Id });
            }
            //TODO: Repopulate dropdown list values.
            return Page();
        }
    }
}