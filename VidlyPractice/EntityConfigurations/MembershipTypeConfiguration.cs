using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
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
        }
    }
}