using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Campaingn
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreationDate { get; set; }
        public int AdminId { get; set; }
        public int AmountType { get; set; }
        public decimal AmountValue { get; set; }
        public bool IsActive { get; set; }
        public AppUser Admin { get; set; }
        public ICollection<CampaignItem> CampaignItems { get; set; }

    }
}
