using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class CommentsMap : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(f => f.Id);
            //foreign key productid
            //foreign key userid
            builder.Property(d => d.Text).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.CreationDate).IsRequired(true).HasColumnType("datetime2").HasMaxLength(7);
            //foreign key parentid
            builder.Property(d => d.IsActive).IsRequired(true).HasColumnType("bit");
            builder.Property(d => d.RateValue).IsRequired(true).HasColumnType("real");

        }
    }
}
