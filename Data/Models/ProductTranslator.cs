using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductTranslator
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TranslatorId { get; set; }
        public decimal TranslatorWagePercent { get; set; }

        public Product Product { get; set; }
        public Person Translator { get; set; }
    }
}
