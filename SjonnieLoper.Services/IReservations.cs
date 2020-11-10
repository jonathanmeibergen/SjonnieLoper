using System.Collections.Generic;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public interface IReservations
    {
        //IEnumerable<string> ReservationWhiskeyTypes();
        IEnumerable<Reservation> AllReservations();
        Reservation ReservationByCustId(int id);
        Reservation ReservationById(int id);
        IEnumerable<Reservation> ReservationsCustomerName(string name);
        Reservation Update(Reservation updatedReservation);
        Reservation Create(Reservation newReservation);
        int Commit();
        
    }
}