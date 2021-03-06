using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class vwProduct
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int AdminId { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime? ConfirmDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
        public int  ProductType { get; set; }
      
    }
}
