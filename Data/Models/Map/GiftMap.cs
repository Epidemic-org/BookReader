using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class GiftMap : IEntityTypeConfiguration<Gift>
    {
        public void Configure(EntityTypeBuilder<Gift> builder)
        {

            builder.HasKey(f => f.Id);

            builder.HasOne(s => s.GiftGiver)
           .WithMany(g => g.GiftGivers)
           .HasForeignKey(s => s.GiftGiverId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.GiftRecipient)
           .WithMany(g => g.GiftRecipients)
           .HasForeignKey(s => s.GiftRecipientId)
           .IsRequired(false)
           .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(s => s.WalletLog)
           .WithMany(g => g.Gifts)
           .HasForeignKey(s => s.WalletLogId)
           .IsRequired(true)
           .OnDelete(DeleteBehavior.NoAction);

            //foreignkey invoiceid
            builder.Property(d => d.GiftCode).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.RecieveDate).IsRequired(false).HasMaxLength(7).HasColumnType("datetime2");
            builder.Property(d => d.CreationDate).IsRequired(true).HasMaxLength(7).HasColumnType("datetime2");

        }
    }
}
