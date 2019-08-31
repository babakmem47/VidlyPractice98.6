using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using VidlyPractice.Models;

namespace VidlyPractice.EntityConfigurations
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Name)
                .HasMaxLength(70)
                .IsRequired();

            Property(m => m.DateAdded)
                .IsOptional();

            Property(m => m.NumberInStock)
                .IsOptional();

            Property(m => m.ReleaseDate)
                .IsOptional();
        }
    }
}