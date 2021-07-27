using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class UserClaimMap : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder) {
            builder.HasKey(t => t.Id);
            builder.Property(d => d.ClaimValue).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.ClaimType).HasMaxLength(50).IsRequired(true).IsUnicode(true);


            builder.HasOne(t => t.User)
            .WithMany(u => u.AppUserClaims)
            .HasForeignKey(t => t.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;

        }
    }
}
