using Microsoft.AspNetCore.Identity;

namespace Employix.Infrastructure.Seeders.Demo
{
    public static class DemoAddRoles
    {
        public static async Task AddDemoRoles(RoleManager<IdentityRole> _roleManager)
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("UserManager"));
            await _roleManager.CreateAsync(new IdentityRole("DepartmentManager"));
            await _roleManager.CreateAsync(new IdentityRole("TeamManager"));
            await _roleManager.CreateAsync(new IdentityRole("TeamMember"));
        }
    }
}
