using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {

        public void Configure(EntityTypeBuilder<AppUser> builder) {
            builder.HasKey(t => t.Id);
            builder.Property(d => d.UserName).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.NormalizedUserName).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.Email).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.NormalizedEmail).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.PasswordHash).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.PhoneNumber).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.LockoutEnd).HasColumnType("datetime2(7)");

            
        }
    }
}
