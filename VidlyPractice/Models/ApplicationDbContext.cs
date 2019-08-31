using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using VidlyPractice.EntityConfigurations;

namespace VidlyPractice.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfigurations());
            modelBuilder.Configurations.Add(new MovieConfiguration());
            modelBuilder.Configurations.Add(new MembershipTypeConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}