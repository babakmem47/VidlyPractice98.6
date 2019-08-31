using System.Data.Entity.ModelConfiguration;

namespace VidlyPractice.Models
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            HasKey(g => g.Id);

            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}