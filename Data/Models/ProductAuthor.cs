using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductAuthor
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AuthorId { get; set; }
        public decimal ProductAuthorWagePercent { get; set; }

        public Product Product { get; set; }
        public Person People { get; set; }
    }
}
