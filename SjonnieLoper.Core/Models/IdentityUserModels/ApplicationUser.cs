using Microsoft.AspNetCore.Identity;

namespace SjonnieLoper.Core
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }
        public ApplicationUser(string name)
        {
            base.UserName = name;
        }
    }
}