using AuthBoilerplateDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthBoilerplateInfrastructure.Persistence
{
    public class StudentDbContext : DbContext
    {
        /* Migration commands
        dotnet ef migrations add InitialCreate --context StudentDbContext --project AuthBoilerplateInfrastructure --startup-project AuthBoilerplate
        dotnet ef database update --context StudentDbContext --project AuthBoilerplateInfrastructure --startup-project AuthBoilerplate
        */

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(x => x.Id);

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "",
                    isActive = true,
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "",
                    Username = "System",
                    Password = "System",
                });
        }
    }
}
