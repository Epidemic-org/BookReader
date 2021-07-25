using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductFileNarrators
    {
        public int Id { get; set; }
        [ForeignKey ("1")]
        public int ProductFileId { get; set; }
        [ForeignKey ("2")]
        public int NarratorId { get; set; }
        public decimal ProductNarrorateWagePercent { get; set; }

    }
}
