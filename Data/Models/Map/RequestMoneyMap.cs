using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class RequestMoneyMap : IEntityTypeConfiguration<RequestMoney>
    {
        public void Configure(EntityTypeBuilder<RequestMoney> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.CreationDate).HasColumnType("datatime2(7)");
            builder.Property(q => q.Description).IsRequired().IsUnicode();
            builder.Property(q => q.AmountValue).HasColumnType("decimal(18,0)");           
            builder.HasOne(q => q.User)
                .WithMany(q => q.RequestMoneys)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
