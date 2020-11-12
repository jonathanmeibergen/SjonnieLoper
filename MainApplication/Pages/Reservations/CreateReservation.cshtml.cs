using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Reservations
{
    public class foo : PageModel
    {
        private readonly IReservations _reservationsDb;
        private readonly IWhiskeys _whiskeysDb;
        public IEnumerable<SelectListItem> RegisteredWhiskeys { get; set; }
        [BindProperty(SupportsGet = true)]
        public int productAddedID { get; set; }
        [BindProperty] public Reservation Reservation { get; set; }

        public foo(IReservations reservations,
            IWhiskeys whiskeysDb,
            IHtmlHelper htmlHelper)
        {
            _reservationsDb = reservations;
            _whiskeysDb = whiskeysDb;
        }

        public IActionResult OnGet()
        {
            Reservation = new Reservation();
            RegisteredWhiskeys = _whiskeysDb
                .AllWhiskeys()
                .GetWhiskeyNames();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                //TODO: Repopulate dropdown list.
                return Page();
            }
            else
            {
                TempData["Message"] = "Created a new reservation.";
                Reservation.Orderdate = DateTime.Now;
                _reservationsDb.Create(Reservation);
            }
            return RedirectToPage("Reservations/Details",
                new {reservationId = Reservation.Id});
        }
    }
}