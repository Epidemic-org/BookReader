using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class vwUserInvoicesMap : IEntityTypeConfiguration<vwUserInvoices>
    {
        public void Configure(EntityTypeBuilder<vwUserInvoices> builder) {
            builder.ToView("vwUserInvoices");
        }
    }
}
