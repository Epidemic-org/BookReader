using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductPublisher
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PublisherId { get; set; }
        public decimal PublisherWagePercent{ get; set; }

        public Product Product { get; set; }
        public People Publisher { get; set; }

    }
}
