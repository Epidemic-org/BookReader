using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceID { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TermAMount { get; set; }

    }
}
