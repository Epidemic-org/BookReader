using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class UserLogMap : IEntityTypeConfiguration<UserLogs>
    {
        public void Configure(EntityTypeBuilder<UserLogs> builder) {
            builder.Property(t => t.Id);
            builder.Property(d => d.UserDevice).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.UserIp).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.CreationDate).HasColumnType("datetime2(7)");

            builder.HasOne(t => t.User)
           .WithMany(u => u.UserLogs)
           .HasForeignKey(t => t.UserId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction)
           ;

        }
    }
}
