using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class CommentLikeMap : IEntityTypeConfiguration<CommentLikes>
    {
        public void Configure(EntityTypeBuilder<CommentLikes> builder)
        {

            builder.HasKey(f => f.Id);

            builder.HasOne(s => s.User)
            .WithMany(g => g.CommentLikes)
            .HasForeignKey(s => s.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.Comment)
            .WithMany(g => g.CommentLikes)
            .HasForeignKey(s => s.CommentId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction);

            builder.Property(d => d.IsLike).IsRequired(true).HasColumnType("bit");
            builder.Property(d => d.CreationDate).IsRequired(true);
           

        }
    }
}
