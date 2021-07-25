using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class CreditType
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal CreditPrice { get; set; }
        public decimal  CreditAmount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public User User { get; set; }
    }
}
