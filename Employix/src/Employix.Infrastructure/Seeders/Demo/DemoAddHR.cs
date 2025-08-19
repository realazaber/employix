using Employix.Domain.Models.Entities;
using Employix.Infrastructure.Repositories;
using Employix.Shared.Enums;
using Microsoft.AspNetCore.Identity;

namespace Employix.Infrastructure.Seeders.Demo
{
    public static class DemoAddHR
    {
        public static async Task AddHR(
            GroupsRepository _groupRepository,
            TeamsRepository _teamRepository,
            DepartmentsRepository _departmentRepository,
            UserManager<User> _userManager,
            RegionsRepository _regionsRepository)
        {

            User hrLeader = new User
            {
                UserName = "dumbridge@employix.com",
                Email = "dumbridge@employix.com",
                ProfileImg = "https://azzaezza.wordpress.com/wp-content/uploads/2016/02/umbridge.jpg?w=640",
                FirstName = "Dolores",
                LastName = "Umbridge",
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(hrLeader, "Umbridge1235*");
            await _userManager.AddToRoleAsync(hrLeader, Roles.TeamManager);

            User hrFilch = new User
            {
                UserName = "afilch@employix.com",
                Email = "afilch@employix.com",
                ProfileImg = "https://static1.srcdn.com/wordpress/wp-content/uploads/2016/12/argus-filch-in-harry-potter.jpg?q=70&fit=contain&w=1200&h=628&dpr=1",
                FirstName = "Argus",
                LastName = "Filch",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(hrFilch, "Filch1235*");
            await _userManager.AddToRoleAsync(hrFilch, Roles.TeamMember);

            User hrCatelynStark = new User
            {
                UserName = "cstark@employix.com",
                Email = "cstark@employix.com",
                ProfileImg = "https://lh6.googleusercontent.com/proxy/Tvh1z34l4Lr1WVQFmYCu07Fb8zOzq7C-UIWr299x_tjHmucz0kDSr2THv8PRGzYXFzveME8_AvTyxoMPEyiP_L8bpjDY8MmPMYcr_OfYMbqHMho",
                FirstName = "Catelyn",
                LastName = "Stark",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(hrCatelynStark, "Stark1235*");
            await _userManager.AddToRoleAsync(hrCatelynStark, Roles.TeamMember);

            Region ukRegion = await _regionsRepository.GetByNameAsync("United Kingdom");

            Group hrGroup = new Group
            {
                Name = "HR Group",
                Description = "A group for all HR related activities.",
                CreatedAt = DateTime.UtcNow,
                Region = ukRegion,
            };

            hrGroup.Members.Add(hrLeader);
            hrGroup.Members.Add(hrFilch);
            hrGroup.Members.Add(hrCatelynStark);

            await _groupRepository.AddAsync(hrGroup);

            Team hrTeam = new Team
            {
                Name = "HR Team",
                Description = "Handles all HR activities.",
                CreatedAt = DateTime.UtcNow,
                Group = hrGroup,
                Region = ukRegion,
            };

            hrTeam.Leaders.Add(hrLeader);

            Department hrDepartment = new Department
            {
                Name = "Human Resources",
                Description = "Responsible for managing employee relations, recruitment, and organizational development.",
                Region = ukRegion,
                CreatedAt = DateTime.UtcNow,
                Leaders = { hrLeader },
            };

            hrDepartment.Teams.Add(hrTeam);
            await _departmentRepository.AddAsync(hrDepartment);
        }
    }
}
