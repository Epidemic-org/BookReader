using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class PermitUserMap : IEntityTypeConfiguration<PermitUser>
    {
        public void Configure(EntityTypeBuilder<PermitUser> builder) {
            builder.HasKey(p => p.Id);


            builder.HasOne(p => p.User)
                .WithMany(p => p.PermitUsers)
                .HasForeignKey(p => p.PermitId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction)
                ;


            builder.HasOne(p => p.Permit)
                .WithMany(p => p.PermitUsers)
                .HasForeignKey(p => p.PermitId)
                .OnDelete(DeleteBehavior.NoAction)
                ;

        }
    }
}
