using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class ShelvesMap : IEntityTypeConfiguration<Shelves>
    {
        public void Configure(EntityTypeBuilder<Shelves> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.ShelfName).IsUnicode().HasMaxLength(100);
            builder.Property(q => q.CreationDate).HasColumnType("datetime2(7)");
            builder.Property(q => q.IsGlobal).HasColumnType("bit");
            builder.HasOne(q => q.User)
                .WithMany(q => q.Shelves)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
