using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookReader.Data.Models.Map
{
    public class PeopleMap : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.BirthDate).HasColumnType("date");

            builder.Property(e => e.FirstName).HasMaxLength(75);

            builder.Property(e => e.IsAcceptRules)
                .IsRequired();

            builder.Property(e => e.LastName).HasMaxLength(75);

            builder.Property(e => e.NationalCode).HasMaxLength(11);

            builder.Property(e => e.Phone).HasMaxLength(11);

            builder.HasOne(d => d.User)
                .WithMany(p => p.Peoples)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(d => new { d.UserId}).IsUnique();
            
        }
    }
}
