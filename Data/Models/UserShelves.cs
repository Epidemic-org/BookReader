using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class UserShelves
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int ShelfId { get; set; }
        public DateTime CreationDate { get; set; }

        public AppUser User { get; set; }
        public Product Product{ get; set; }
        public Shelves Shelve { get; set; }

    }
        
}
