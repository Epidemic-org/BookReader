using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class AppRoleClaimMap : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            builder.Property(d => d.ClaimType).IsUnicode(true).IsRequired(false);
            builder.Property(d => d.ClaimValue).IsUnicode(true).IsRequired(false);

            builder.HasOne(d => d.Role).
                WithMany(d => d.AppRoleClaims).
                HasForeignKey(d => d.RoleId).
                OnDelete(DeleteBehavior.NoAction;
        }
    }
}
