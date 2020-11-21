using Microsoft.AspNetCore.Identity;

namespace SjonnieLoper.Core.Models
{
    public class Customer : IdentityUser
    {
        public override string UserName { get; set; }

        public Customer(string name)
        {
            UserName = name;
        }
        public Customer(string name, string id)
        {
            this.Id = id;
            UserName = name;
        } 
    }
}