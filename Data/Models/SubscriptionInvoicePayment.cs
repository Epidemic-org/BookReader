using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class SubscriptionInvoicePayment
    {
        public int Id { get; set; }
        public int SubscriptionInvoiceId { get; set; }
        public decimal PayAmount { get; set; }
        public int TransactionId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
