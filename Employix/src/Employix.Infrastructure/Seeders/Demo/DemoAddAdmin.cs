using Employix.Domain.Models.Entities;
using Employix.Shared.Enums;
using Microsoft.AspNetCore.Identity;

namespace Employix.Infrastructure.Seeders.Demo
{
    public static class DemoAddAdmin
    {
        public static async Task AddAdmin(UserManager<User> _userManager)
        {

            User adminUser = new User
            {
                UserName = "admin@employix.com",
                Email = "admin@employix.com",
                ProfileImg = "https://media.licdn.com/dms/image/v2/D4D03AQHMUYl6EsQOFQ/profile-displayphoto-shrink_800_800/B4DZUirdcwHYAg-/0/1740043573911?e=1755734400&v=beta&t=1sH9fRYrzmw-N6EgL5PDuC6Dp6VYP7wcrVOYumvVUm8",
                FirstName = "Alex",
                LastName = "Zaborski",
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(adminUser, "Admin1235*");
            await _userManager.AddToRoleAsync(adminUser, Roles.Admin);
            await _userManager.AddToRoleAsync(adminUser, Roles.UserManager);
            await _userManager.AddToRoleAsync(adminUser, Roles.DepartmentManager);
            await _userManager.AddToRoleAsync(adminUser, Roles.TeamManager);
        }
    }
}
