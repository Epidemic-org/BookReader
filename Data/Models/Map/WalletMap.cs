using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class WalletMap : IEntityTypeConfiguration<WalletLog>
    {
        public void Configure(EntityTypeBuilder<WalletLog> builder) {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.WalletValue).IsRequired(true).HasColumnType("decimal").HasPrecision(18, 2);
            builder.Property(d => d.CreationDate).HasColumnType("datetime2(7)");
            builder.Property(d => d.Description).HasMaxLength(500).IsRequired(true).IsUnicode(true);


             builder.HasOne(t => t.User)
            .WithMany(u => u.WalletLogs)
            .HasForeignKey(t => t.UserId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;


            builder.HasOne(t => t.Transaction)
            .WithMany(u => u.WalletLogs)
            .HasForeignKey(t => t.TransactionId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.NoAction)
            ;


        }
    }
}
