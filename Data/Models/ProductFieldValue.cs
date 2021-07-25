using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductFieldValue
    {
        public int ProductId { get; set; }
        public int FieldId { get; set; }
        public int FieldValueId { get; set; }
    }
}
