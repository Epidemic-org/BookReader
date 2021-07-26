using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(f => f.Id);

            builder.HasOne(s => s.Product)
            .WithMany(g => g.Comments)
            .HasForeignKey(s => s.ProductId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.User)
            .WithMany(g => g.Comments)
            .HasForeignKey(s => s.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Parent)
           .WithMany(g => g.Comments)
           .HasForeignKey(s => s.ParentId)
           .IsRequired(false)
           .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.Text).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.CreationDate).IsRequired(true).HasColumnType("datetime2").HasMaxLength(7);
            //foreign key parentid
            builder.Property(d => d.IsActive).IsRequired(true).HasColumnType("bit");
            builder.Property(d => d.RateValue).IsRequired(true).HasColumnType("real");

        }
    }
}
