using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class SubscriptionTypeItems
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductId { get; set; }
        public int SubcriptionTypeId { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<SubscriptionType> subscriptionTypes  { get; set; }
    }
}
