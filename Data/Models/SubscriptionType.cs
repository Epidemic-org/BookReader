using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class SubscriptionType
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int DayCount { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal PriceAmount { get; set; }
        public bool IsActive { get; set; }
        public string Icon { get; set; }
        public string Pic { get; set; }
    }
}
