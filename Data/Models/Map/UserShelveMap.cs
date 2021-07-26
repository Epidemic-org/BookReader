using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class UserShelveMap : IEntityTypeConfiguration<UserShelves>
    {
        public void Configure(EntityTypeBuilder<UserShelves> builder) {
            builder.HasKey(t => t.Id);
            builder.Property(d => d.CreationDate).HasColumnType("datetime2(7)");

            builder.HasOne(t => t.User)
            .WithMany(u => u.UserShelves)
            .HasForeignKey(t => t.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;

            builder.HasOne(t => t.Product)
            .WithMany(u => u.UserShelves)
            .HasForeignKey(t => t.ProductId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;


            builder.HasOne(t => t.Shelve)
            .WithMany(u => u.UserShelves)
            .HasForeignKey(t => t.ShelfId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;




        }
    }
}
