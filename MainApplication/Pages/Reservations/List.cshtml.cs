using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SjonnieLoper.Services;
using SjonnieLoper.Core;
using SjonnieLoper.Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace SjonnieLoper.Pages.Reservations
{
    [Authorize(Policy = "EmployeeOnly")]
    //[AllowAnonymous]
    public class ListModel : PageModel
    {
        private readonly IReservations _reservationsDb;

        public ListModel(IReservations reservations)
        {
            _reservationsDb = reservations;
        }
        
        public SelectList ResTypes { get; set; } 

        [BindProperty(SupportsGet = true)]
        public string ProductType { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }
        //[BindProperty] 
        public IEnumerable<Reservation> RetrievedReservations { get; set; }


        public void OnGet()
        {
            RetrievedReservations = String.IsNullOrEmpty(SearchValue)
                ? _reservationsDb.AllReservations()
                : _reservationsDb.ReservationsCustomerName(SearchValue);
            
           // ResTypes = new SelectList(_reservationsDb.ReservationWhiskeyTypes());
        }

    }
}