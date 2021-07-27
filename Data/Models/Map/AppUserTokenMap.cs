using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class AppUserTokenMap : IEntityTypeConfiguration<AppUserToken>
    {
        public void Configure(EntityTypeBuilder<AppUserToken> builder) {
            builder.HasKey(u => new { u.UserId, u.LoginProvider, u.Name});
            builder.Property(d => d.LoginProvider).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.Name).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.Value).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.HasOne(t => t.User)
            .WithMany(u => u.UserTokens)
            .HasForeignKey(t => t.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;

        }
    }
}
