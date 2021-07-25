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
        [ForeignKey ("1")]
        public int UserId { get; set; }
        [ForeignKey("2")]
        public int ProductId { get; set; }
        [ForeignKey("3")]
        public int ShelfId { get; set; }
        public DateTime CreationDate { get; set; }

    }
        
}
