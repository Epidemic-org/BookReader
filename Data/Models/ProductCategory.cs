using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public string Pic { get; set; }

        //[NotMapped]
        //public IFormFile PicFile { get; set; }

        public string Icon { get; set; }
        //[NotMapped]
        //public IFormFile IconFile { get; set; }

        public bool IsActive { get; set; }
        public int AdminId { get; set; }
        public DateTime CreationDate { get; set; }
        public int ProductType { get; set; }


        public AppUser Admin { get; set; }
        public ProductCategory Parent { get; set; }


        public ICollection<Product> Products { get; set; }
        public ICollection<CampaignItem> CampaignItems { get; set; }
        public ICollection<ProductAuthor> ProductAuthors { get; set; }
        public ICollection<ProductCategoryField> ProductCategoryFields { get; set; }
        public ICollection<ScoreTypeItem> ScoreTypeItems { get; set; }
        public ICollection<SubscriptionInvoiceItem> SubscriptionInvoiceItems { get; set; }
        public ICollection<SubscriptionTypeItem> SubscriptionTypeItems { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }


    }
}
