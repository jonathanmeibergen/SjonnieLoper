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
    public class CreateModel : PageModel
    {
        private readonly IReservations _reservationsDb;
        private readonly IWhiskeys _whiskeysDb;
        public IEnumerable<SelectListItem> RegisteredWhiskeys { get; set; }
        [BindProperty] public Reservation Reservation { get; set; }

        public CreateModel(IReservations reservations,
            IWhiskeys whiskeysDb,
            IHtmlHelper htmlHelper)
        {
            _reservationsDb = reservations;
            _whiskeysDb = whiskeysDb;
            var allWhiskey = _whiskeysDb.AllWhiskeys();
        }

        public void OnGet(int reservationId)
        {
            Reservation = new Reservation();
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