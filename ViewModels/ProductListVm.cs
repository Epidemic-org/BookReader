using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class ProductListVm
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public DateTime CreationDate { get; set; }
        public string NCreationDate {
            get {
                return CreationDate.ToPersianDateTimeString();
            }

            set {
                CreationDate = value.ToEnglishDateTime();
            }
        }
        public DateTime? EditionDate { get; set; }
        public int ProductType { get; set; }
        public decimal Price { get; set; }
        public decimal RateAverage { get; set; }
        
    }
}
