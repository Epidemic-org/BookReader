using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string TrackingCode { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsSuccess { get; set; }
        public string Description { get; set; }

        public ICollection<InvoicePayment> InvoicePayments { get; set; }        
        public ICollection<SubscriptionInvoicePayment> SubscriptionInvoicePayments { get; set; }
        public ICollection<WalletLog> WalletLogs { get; set; }

    }
}
