using Microsoft.AspNetCore.Identity;

namespace Employix.Domain.Models.Entities
{

    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

}
