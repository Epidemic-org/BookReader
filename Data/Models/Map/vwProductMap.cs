using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class vwProductMap : IEntityTypeConfiguration<vwProduct>
    {
        public void Configure(EntityTypeBuilder<vwProduct> builder)
        {
            //builder.ToTable("prrrr");
            builder.ToView("vwProducts");
        }
    }
}
