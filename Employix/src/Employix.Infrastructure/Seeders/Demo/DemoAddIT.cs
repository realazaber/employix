using Employix.Domain.Models.Entities;
using Employix.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Employix.Infrastructure.Seeders.Demo
{
    public static class DemoAddIT
    {
        public static async Task AddIT(GroupsRepository _groupRepository,
                                       TeamsRepository _teamRepository,
                                       DepartmentsRepository _departmentRepository,
                                       UserManager<User> _userManager)
        {
            User itAdmin = new User
            {
                UserName = "sirwin@employix.com",
                Email = "sirwin@employix.com",
                FirstName = "Steve",
                LastName = "Irwin",
                ProfileImg = "https://hips.hearstapps.com/hmg-prod/images/gettyimages-1129401.jpg",
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(itAdmin, "Steve1235*");
            await _userManager.AddToRoleAsync(itAdmin, "TeamManager");

            User itObiwan = new User
            {
                UserName = "okenobi@employix.com",
                Email = "okenobi@employix.com",
                FirstName = "ObiWan",
                LastName = "Kenobi",
                ProfileImg = "https://platform.theverge.com/wp-content/uploads/sites/2/chorus/uploads/chorus_asset/file/9068883/Obi_Wan.jpg?quality=90&strip=all&crop=12.5,0,75,100",
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(itObiwan, "ObiWan1235*");
            await _userManager.AddToRoleAsync(itObiwan, "TeamMember");

            User itRobinWill = new User
            {
                UserName = "rwilliams@employix.com",
                Email = "rwilliams@employix.com",
                FirstName = "Robin",
                LastName = "Williams",
                ProfileImg = "https://cdn.britannica.com/82/130482-050-87C2665C/Actor-Robin-Williams.jpg",
                EmailConfirmed = true
            };
            await _userManager.CreateAsync(itRobinWill, "RobWill1235*");
            await _userManager.AddToRoleAsync(itRobinWill, "TeamMember");


            Group itGroup = await _groupRepository.AddAsync(new Group
            {
                Name = "IT Group",
                Description = "A group for all IT related activities.",
                CreatedAt = DateTime.UtcNow,
            });
            itGroup.Members.Add(itAdmin);
            itGroup.Members.Add(itObiwan);
            itGroup.Members.Add(itRobinWill);
            itGroup.Members.Add(itAdmin);

            Team itTeam = new Team
            {
                Name = "IT Team",
                Description = "Handles all IT activities.",
                CreatedAt = DateTime.UtcNow,
                Group = itGroup,
            };
            itTeam.Leaders.Add(itAdmin);
            await _teamRepository.AddAsync(itTeam);

            Department itDepartment = new Department
            {
                Name = "IT",
                Description = "Responsible for managing the company's IT infrastructure.",
                CreatedAt = DateTime.UtcNow,
                Leaders = new List<User> { itAdmin },
            };
            itDepartment.Teams.Add(itTeam);
            await _departmentRepository.AddAsync(itDepartment);
        }
    }
}
