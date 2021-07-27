using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class UserLoginMap : IEntityTypeConfiguration<AppUserLogin>
    {
        public void Configure(EntityTypeBuilder<AppUserLogin> builder) {
            builder.Property(d => d.LoginProvider).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.ProviderKey).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.ProviderDisplayName).HasMaxLength(50).IsRequired(true).IsUnicode(true);


            builder.HasOne(t => t.User)
            .WithMany(u => u.UserLogins)
            .HasForeignKey(t => t.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;


        }
    }
}
