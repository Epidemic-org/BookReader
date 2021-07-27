using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder) {
            builder.HasKey(t => new { t.UserId, t.RoleId });
            builder.HasOne(t => t.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(t => t.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;

            builder.HasOne(t => t.Role)
            .WithMany(u => u.AppUserRoles)
            .HasForeignKey(t => t.RoleId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;

        }
    }
}
