using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class InvoiceTerm
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int TermTypeId { get; set; }
        public decimal TermAmount { get; set; }
    }
}
