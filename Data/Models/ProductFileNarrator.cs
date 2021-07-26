using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductFileNarrator
    {
        public int Id { get; set; }
        public int ProductFileId { get; set; }
        public int NarratorId { get; set; }
        public decimal ProductNarrorateWagePercent { get; set; }
        public People Narrator { get; set; }
        public ProductFile ProductFile { get; set; }
    }
}
