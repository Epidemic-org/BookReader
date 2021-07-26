using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int UserId { get; set; }
        public int AdminId { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime ConfirmDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditionDate { get; set; }
        public int  ProductType { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public User User { get; set; }
        public User Admin { get; set; }
        public ICollection<CampaignItem> CampaignItems { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<ProductDownload> ProductDownloads { get; set; }
        public ICollection<ProductFieldValue> ProductFieldValues { get; set; }
        public ICollection<ProductFile> ProductFiles { get; set; }
        public ICollection<ProductAuthor> ProductAuthors { get; set; }
        public ICollection<ProductPlay> ProductPlays{ get; set; }
        public ICollection<ProductPrice> ProductPrices{ get; set; }
        public ICollection<ProductPublisher> ProductPublishers { get; set; }
        public ICollection<ProductRate> ProductRates { get; set; }
        public ICollection<ProductRelation> ProductRelations { get; set; }
        public ICollection<ProductRelation> RelatedProductRelations { get; set; }
        public ICollection<ProductTranslator> ProductTranslators { get; set; }
        public ICollection<ProductVisit> ProductVisits { get; set; }
        public ICollection<ScoreTypeItem> ScoreTypeItems { get; set; }
        public ICollection<SubscriptionInvoiceItem> SubscriptionInvoiceItem { get; set; }
        public ICollection<SubscriptionTypeItem> SubscriptionTypeItem { get; set; }


    }
}
