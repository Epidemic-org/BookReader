using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermitGenerationId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalTerms { get; set; }
        public decimal PayableAmount { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }


        public AppUser User { get; set; }
        public PermitGeneration PermitGeneration { get; set; }

        public ICollection<Gift> Gifts { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
        public ICollection<InvoiceTerm> InvoiceTerms { get; set; }
        public ICollection<InvoicePayment> InvoicePayments { get; set; }

    }
}
