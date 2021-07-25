using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductRates
    {
        public int Id { get; set; }
        [ForeignKey ("1")]
        public int UserId { get; set; }
        [ForeignKey("2")]
        public int ProductId { get; set; }
        public double RateValue { get; set; } // real value : c# ??
        public DateTime  CreationDate { get; set; }

    }
}
