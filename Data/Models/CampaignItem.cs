using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class CampaignItem
    {
        public int Id { get; set; }

        public int CampaingnId { get; set; }

        public int ProductCategoryId { get; set; }

        public int ProductId { get; set; }

        public Campaingn Campaingn { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public Product Product { get; set; }
    }
}
