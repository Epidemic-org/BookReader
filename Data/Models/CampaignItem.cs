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
        [ForeignKey("1")]
        public int CampaingnId { get; set; }
        [ForeignKey("2")]
        public int ProductCategory { get; set; }
        [ForeignKey("3")]
        public int ProductId { get; set; }
    }
}
