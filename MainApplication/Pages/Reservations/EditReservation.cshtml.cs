using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Components;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Reservations
{
    public class EditModel : PageModel
    {
        private readonly IReservations _reservationsDb;
        private readonly ISqlWhiskeys _whiskeys;
        public IEnumerable<SelectListItem> RegisteredWhiskeys { get; set; }
        [BindProperty(SupportsGet = true)]
        public int productAddedID { get; set; }
        [BindProperty]
        public Reservation Reservation { get; set; }

        public EditModel(IReservations reservations,
                        ISqlWhiskeys whiskeysDb)
        {
            _reservationsDb = reservations;
            _whiskeys = whiskeysDb;

        }
        public async Task<IActionResult> OnGet(int reservationId)
        {
            RegisteredWhiskeys = _whiskeys
                .GetAll()
                .Result
                .GetWhiskeysSelectList();
            Reservation = await _reservationsDb.ReservationById(reservationId);
            if (Reservation == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Reservation.Product = new Whiskey(await _whiskeys.GetById(productAddedID));
                TempData["Message"] = "Created a new reservation.";
                await _reservationsDb.Update(Reservation);
                await _reservationsDb.Commit();
                return RedirectToPage("./Details", 
                    new { reservationId = Reservation.Id });
            }
            //TODO: Repopulate dropdown list values.
            return Page();
        }
    }
}