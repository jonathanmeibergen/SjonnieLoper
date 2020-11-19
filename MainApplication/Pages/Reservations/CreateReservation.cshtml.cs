using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Core;
using SjonnieLoper.Core.Models;
using SjonnieLoper.Services;

namespace SjonnieLoper.Pages.Reservations
{
    [Authorize(Policy = "EmployeeOnly")]
    public class CreateModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IReservations _reservationsDb;
        private readonly IWhiskeys _whiskeys;

        [BindProperty(SupportsGet = true)]
        public int productId { get; set; }
        public Whiskey Whiskey { get; set; }
        [BindProperty] public Reservation Reservation { get; set; }
        public CreateModel(IReservations reservations,
            IWhiskeys whiskeys,
            IHtmlHelper htmlHelper,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _reservationsDb = reservations;
            _whiskeys = whiskeys;
        }

        public void OnGet(int productId)
        {
            Reservation = new Reservation();
            Reservation.Product = _whiskeys.GetById(productId);
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                TempData["Message"] = "Created a new reservation.";
                Reservation.Orderdate = DateTime.Now;
                Reservation.User =  await _userManager.GetUserAsync(User);
                Reservation.Product = await _whiskeys.WhiskeyById(productAddedID);

                Reservation = await _reservationsDb.Create(Reservation);
                await _reservationsDb.Commit();
            }
            return RedirectToPage("Reservations/DetailsReservation",
                new {reservationId = Reservation.Id});
        }
    }
}