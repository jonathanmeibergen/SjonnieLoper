using System.Buffers.Text;
using System.ComponentModel;
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
        
        public ReservationViewModel(){}

        [DisplayName("Name client ")]
        public override string ClientName
        {
            get => Customer.UserName;
            set => Customer.UserName = value;
        }
    }
}