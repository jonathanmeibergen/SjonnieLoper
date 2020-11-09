using SjonnieLoper.Core.Models;

namespace SjonnieLoper.Pages.ViewModels
{
    public class WhiskeyViewModel : Whiskey
    {
        public WhiskeyViewModel(Whiskey product)
            :base(product)
        {
            
        }

        public WhiskeyViewModel()
        {
        }
    }
}