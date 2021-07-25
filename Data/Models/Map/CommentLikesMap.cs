using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class CommentLikesMap : IEntityTypeConfiguration<CommentLikes>
    {
        public void Configure(EntityTypeBuilder<CommentLikes> builder)
        {

            builder.HasKey(f => f.Id);
            //foreign key UserId
            //foreign key CommentId
            builder.Property(d => d.IsLike).IsRequired(true).HasColumnType("bit");
            builder.Property(d => d.CreationDate).IsRequired(true);
           

        }
    }
}
