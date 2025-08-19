using Employix.Domain.Models.Entities;
using Employix.Infrastructure.Repositories;
using Employix.Shared.Enums;
using Microsoft.AspNetCore.Identity;

namespace Employix.Infrastructure.Seeders.Demo
{
    public static class DemoAddMarketing
    {
        public static async Task AddMarketing(Repository<Group> _groupRepository,
                                              TeamsRepository _teamRepository,
                                              DepartmentsRepository _departmentRepository,
                                              UserManager<User> _userManager,
                                              RegionsRepository _regionRepository)
        {
            User marketingDepartmentLead = new User
            {
                UserName = "pugsley@employix.com",
                Email = "pugsley@employix.com",
                ProfileImg = "https://images.pexels.com/photos/3813324/pexels-photo-3813324.jpeg",
                FirstName = "Pugsley",
                LastName = "Adams",
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(marketingDepartmentLead, "Pugsley123*");
            await _userManager.AddToRoleAsync(marketingDepartmentLead, Roles.TeamManager);


            User marketingRobbStark = new User
            {
                UserName = "rstark@employix.com",
                Email = "rstark@employix.com",
                ProfileImg = "https://cdn.costumewall.com/wp-content/uploads/2019/07/robb-stark.jpg",
                FirstName = "Robb",
                LastName = "Stark",
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(marketingRobbStark, "Robb1235*");
            await _userManager.AddToRoleAsync(marketingRobbStark, Roles.TeamMember);

            Region globalRegion = await _regionRepository.GetByNameAsync("Global");


            Group marketingGroup = new Group
            {
                Name = "Marketing Group",
                Description = "A group for all marketing related activities.",
                CreatedAt = DateTime.UtcNow,
                Region = globalRegion,
            };

            marketingGroup.Members.Add(marketingRobbStark);
            marketingGroup.Members.Add(marketingDepartmentLead);

            await _groupRepository.AddAsync(marketingGroup);

            Team marketingTeam = new Team
            {
                Name = "Marketing Team",
                Description = "Handles all marketing activities.",
                CreatedAt = DateTime.UtcNow,
                Group = marketingGroup,
                Region = globalRegion,

            };
            marketingTeam.Leaders.Add(marketingDepartmentLead);

            await _teamRepository.AddAsync(marketingTeam);



            Department marketingDepartment = new Department
            {
                Name = "Marketing",
                Description = "Responsible for promoting the company's products and services.",
                Region = globalRegion,
                CreatedAt = DateTime.UtcNow,
                Leaders = new List<User> { marketingDepartmentLead }
            };

            marketingDepartment.Teams.Add(marketingTeam);
            await _departmentRepository.AddAsync(marketingDepartment);
        }
    }
}
