using System.Data.Entity.ModelConfiguration;
using VidlyPractice.Models;

namespace VidlyPractice.EntityConfigurations
{
    public class MembershipTypeConfiguration : EntityTypeConfiguration<MembershipType>
    {
        public MembershipTypeConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.SigUpFee)
                .IsRequired();

            Property(m => m.DurationInMonth)
                .IsRequired();

            Property(m => m.DiscountRate)
                .IsRequired();

            Property(m => m.Name)
                .HasMaxLength(50);
        }
    }
}