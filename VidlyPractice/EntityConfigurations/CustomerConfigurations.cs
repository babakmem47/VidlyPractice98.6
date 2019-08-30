using System.Data.Entity.ModelConfiguration;
using VidlyPractice.Models;

namespace VidlyPractice.EntityConfigurations
{
    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}