using Employix.Domain.Models.Entities;
using Employix.Infrastructure.Data;
using Employix.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Employix.Infrastructure.Seeders.Demo
{
    public static class DemoSeeder
    {
        public static async Task<WebApplication> AddDemoDefaults(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                AppDbContext _dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (_dbContext.Users.Any() || _dbContext.Roles.Any())
                {
                    return app;
                }
                UserManager<User> _userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                RoleManager<IdentityRole> _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                GroupsRepository _groupRepository = scope.ServiceProvider.GetRequiredService<GroupsRepository>();
                TeamsRepository _teamRepository = scope.ServiceProvider.GetRequiredService<TeamsRepository>();
                DepartmentsRepository _departmentRepository = scope.ServiceProvider.GetRequiredService<DepartmentsRepository>();

                await DemoAddRoles.AddDemoRoles(_roleManager);
                await DemoAddAdmin.AddAdmin(_userManager);
                await DemoAddMarketing.AddMarketing(_groupRepository, _teamRepository, _departmentRepository, _userManager);
                await DemoAddIT.AddIT(_groupRepository, _teamRepository, _departmentRepository, _userManager);
                await DemoAddHR.AddHR(_groupRepository, _teamRepository, _departmentRepository, _userManager);

                return app;
            }
        }
    }
}
