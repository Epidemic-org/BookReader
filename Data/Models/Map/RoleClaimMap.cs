using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class RoleClaimMap : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.ClaimType).IsRequired(false).IsUnicode();
            builder.Property(q => q.ClaimValue).IsRequired(false).IsUnicode();
            builder.HasOne(q => q.Role)
                .WithMany(q => q.RoleClaims)
                .HasForeignKey(q => q.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
