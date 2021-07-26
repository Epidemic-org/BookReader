using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductPrice
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPriceValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public int AdminId { get; set; }
        public User Admin { get; set; }
        public Product Product { get; set; }

    }
}
