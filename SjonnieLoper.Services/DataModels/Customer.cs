using Microsoft.AspNetCore.Identity;

namespace SjonnieLoper.Services.DataModels.Core.Models
{
    public class Customer : IdentityUser
    {
        public Customer(string name)
        {
            this.UserName = name;
        }
    }
}