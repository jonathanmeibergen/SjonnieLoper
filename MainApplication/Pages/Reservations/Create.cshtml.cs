using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly IReservations _reservationsDb;
        private readonly IWhiskeys _whiskeys;
        public IEnumerable<SelectListItem> RegisteredWhiskeys { get; set; }
        [BindProperty(SupportsGet = true)]
        public int productAddedID { get; set; }
        [BindProperty] public Reservation Reservation { get; set; }

        public CreateModel(IReservations reservations,
            IWhiskeys whiskeys,
            IHtmlHelper htmlHelper)
        {
            _reservationsDb = reservations;
            _whiskeys = whiskeys;
            var allWhiskey = _whiskeys.AllWhiskeys();
        }

        public void OnGet(int reservationId)
        {
            Reservation = new Reservation();
            RegisteredWhiskeys = _whiskeys
                .AllWhiskeys()
                .GetWhiskeyNames();
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