using System.Buffers.Text;
using System.ComponentModel.DataAnnotations;
using SjonieLoper.Core.Models;

namespace SjonnieLoper.Pages.ViewModels
{
    public class ReservationViewModel : Reservation
    {
        public ReservationViewModel(Reservation reservation)
            :base(reservation)
        {
        }

        [Display(Name="Name client")]
        public override string ClientName
        {
            get => Customer.UserName;
            set => Customer.UserName = value;
        }
    }
}