using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public string Pic { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
        public int AdminId { get; set; }
        public DateTime CreationDate { get; set; }
        public int ProductType { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<ProductCategory> ParentCategories { get; set; }
    }
}
