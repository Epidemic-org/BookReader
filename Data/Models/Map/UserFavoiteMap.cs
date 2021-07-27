using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class UserFavoiteMap : IEntityTypeConfiguration<UserFavorites>
    {
        public void Configure(EntityTypeBuilder<UserFavorites> builder) {
            builder.Property(t => t.Id);
            builder.Property(d => d.CreationDate).HasColumnType("datetime2(7)");


            builder.HasOne(t => t.User)
            .WithMany(u => u.UserFavorites)
            .HasForeignKey(t => t.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;
            builder.HasOne(t => t.Product)
           .WithMany(u => u.UserFavorites)
           .HasForeignKey(t => t.ProductId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction)
           ;
        }
    }
}
