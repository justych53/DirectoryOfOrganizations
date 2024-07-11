using DirectoryOrganizations.Models;
using Microsoft.EntityFrameworkCore;

namespace DirectoryOrganizations.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() 
        {
            Database.Migrate();
        }
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Organization> Organizations { get; set; } = null!;
        public DbSet<Branch> Branches { get; set; } = null!;
        public DbSet<Address> Address { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DirectoryOrganizations;Username=postgres;Password=2212");
            //optionsBuilder.UseNpgsql("Host=web01;Port=5432;Database=DirectoryOrganizations;Username=postgres;Password=postgres");
        }
    }
}
