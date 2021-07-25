using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ScoreTypeItem
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public int ScoreId { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Product Product { get; set; }
        public ScoreType ScoreType { get; set; }
    }
}
