using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductCategoryField
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public int FieldId { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public Field Field { get; set; }
    }
}
