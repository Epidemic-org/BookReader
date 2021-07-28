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

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {

            var hasher = new Microsoft.AspNetCore.Identity.PasswordHasher<AppUser>();
            
            builder.HasData(new AppUser
            {
                Id = 1,
                
                IsActive = true,
                TwoFactorEnabled = false,
                Email = "AbbasKashi69@gmail.com",
                UserName = "09132602521",
                NormalizedUserName = "09132602521",
                NormalizedEmail = "09132602521",
                PhoneNumberConfirmed = true,
                PhoneNumber = "09132602521",
                PasswordHash = hasher.HashPassword(null, "Abbas1369"),
                SecurityStamp = Guid.NewGuid().ToString()
            });
        }
    }
}
