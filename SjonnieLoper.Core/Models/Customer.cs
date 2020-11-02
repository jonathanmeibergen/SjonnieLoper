using Microsoft.AspNetCore.Identity;

namespace SjonnieLoper.Core
{
    public class Customer : IdentityUser
    {
        public Customer(string name)
        {
            this.UserName = name;
        }
    }
}