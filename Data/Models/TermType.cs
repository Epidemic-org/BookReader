using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class TermType
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string Title { get; set; }
        public decimal TermValue { get; set; }
        public int AmountType { get; set; }
        public int TermType1 { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public AppUser Admin { get; set; }
        public ICollection<InvoiceTerm> InvoiceTerms { get; set; }
        public ICollection<Permit> Permits { get; set; }
    }
}
