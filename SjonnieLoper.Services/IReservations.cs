using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Services
{
    public interface IReservations
    {
        //IEnumerable<string> ReservationWhiskeyTypes();
        Task <IEnumerable<Reservation>> AllReservations();
        Task <Reservation> ReservationByCustId(int id);
        Task<Reservation> ReservationById(int id);
        Task <IEnumerable<Reservation>> ReservationsUserName(string name);
        Task <Reservation> Update(Reservation updatedReservation);
        Task <Reservation> Create(Reservation newReservation);
        Task <int> Commit();
        Task <Reservation> Delete(int id);
    }
}