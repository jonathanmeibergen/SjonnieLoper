using Microsoft.AspNetCore.Identity;

namespace SjonnieLoper.Core.Models
{
    public class Customer : IdentityUser
    {
        public Customer(string name)
        {
            this.UserName = name;
        }
    }
}