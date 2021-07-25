using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class GiftsMap : IEntityTypeConfiguration<Gift>
    {
        public void Configure(EntityTypeBuilder<Gift> builder)
        {

            builder.HasKey(f => f.Id);
            //foreignkey giftgiverid
            //foreignkey giftrecipientid
            //foreignkey walletid
            //foreignkey invoiceid
            builder.Property(d => d.GiftCode).IsRequired(true).IsUnicode(true);
            builder.Property(d => d.RecieveDate).IsRequired(false).HasMaxLength(7).HasColumnType("datetime2");
            builder.Property(d => d.CreationDate).IsRequired(true).HasMaxLength(7).HasColumnType("datetime2");

        }
    }
}
