using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Comments
    {
        public int Id { get; set; }
        [ForeignKey ("1")]
        public int ProductId { get; set; }
        [ForeignKey("2")]
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        [ForeignKey("3")]
        public int ParentId { get; set; }
        public int IsActive { get; set; }
        public double RateValue { get; set; } //real value in sql : in c# ??

    }
}
