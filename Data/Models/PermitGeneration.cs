using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class PermitGeneration
    {
        public int Id { get; set; }
        public int PermitId { get; set; }
        public int UserId { get; set; }
        public int PermitCode { get; set; }
        public int AmountType { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreationDate { get; set; }
        public User User { get; set; }
        public Permit Permit { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

    }
}
