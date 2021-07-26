using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder) {
            builder.HasKey(t => t.Id);
            builder.Property(d => d.TrackingCode).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.BankName).HasMaxLength(50).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.Description).HasMaxLength(500).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.CreationDate).HasColumnType("datetime2(7)");
            builder.Property(t => t.Amount).IsRequired(true).HasColumnType("decimal").HasPrecision(18, 2);

        }
    }
}
