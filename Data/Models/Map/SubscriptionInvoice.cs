using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models.Map
{
    public class SubscriptionInvoice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DayCount { get; set; }
        public int PermitGenerationId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalTerms { get; set; }
        public decimal PayableAmount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SubscriptionTypeDescription { get; set; }
        public string SubscriptionTypeTitle { get; set; }

    }
}
