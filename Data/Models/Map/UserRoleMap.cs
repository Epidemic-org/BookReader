using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder) {
            builder.HasKey(t => t.Id);

            builder.HasOne(t => t.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(t => t.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;


            builder.HasOne(t => t.Role)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(t => t.RoleId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;



        }
    }
}
