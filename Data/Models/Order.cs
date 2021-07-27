using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Order 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Address { get; set; }

        public AppUser User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
