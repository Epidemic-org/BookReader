using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class RolePermissionMap : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasKey(q => q.Id);
            builder.HasOne(q => q.Role)
                .WithMany(q => q.RolePermissions)
                .HasForeignKey(q => q.RoleId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(q => q.FormAction)
                .WithMany(q => q.RolePermissions)
                .HasForeignKey(q => q.FormId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
