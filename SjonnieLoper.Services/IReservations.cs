using System.Collections.Generic;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public interface IReservations
    {
        //IEnumerable<string> ReservationWhiskeyTypes();
        IEnumerable<Reservation> AllReservations();
        Reservation ReservationByCustId(int id);
        Reservation ReservationById(int id);
        IEnumerable<Reservation> ReservationsUserName(string name);
        Reservation Update(Reservation updatedReservation);
        Reservation Create(Reservation newReservation);
        int Commit();
        Reservation Delete(int id);
    }
}