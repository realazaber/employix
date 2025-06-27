using Employix.Domain.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Employix.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Department> Departments { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<User> Users { get; set; }
    }

}
