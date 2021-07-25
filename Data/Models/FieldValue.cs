using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class FieldValue
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public string Value { get; set; }
        public Field Field { get; set; }
    }
}
