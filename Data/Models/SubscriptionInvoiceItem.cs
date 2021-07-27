using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class SubscriptionInvoiceItem
    {
        public int Id { get; set; }
        public int SubscriptionInvoiceId { get; set; }
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }

        public SubscriptionInvoice SubscriptionInvoice { get; set; }
        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }

    }
}
