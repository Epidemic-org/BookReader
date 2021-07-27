using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder.Property(t => t.Id);
            builder.Property(d => d.Address).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.CreationDate).HasColumnType("datetime2(7)");


            builder.HasOne(t => t.User)
           .WithMany(u => u.Orders)
           .HasForeignKey(t => t.UserId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction)
           ;

        }

    }
}
