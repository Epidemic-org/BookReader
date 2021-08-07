using BookReader.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class ProductListByCategoryVm
    {
        [Display(Name = "عنوان")]

        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string Title { get; set;}
        public ICollection<ProductAuthor> ProductAuthors { get; set; }
        public string AuthorFullName { get; set; }
        public ICollection<ProductPrice> ProductPrices { get; set; }

        public ICollection<ProductRate> ProductRates { get; set; }
    }
}
