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
        public string Title { get; set;}
        public decimal ProductPrices { get; set; }
        public string AuthorFullName { get; set; }        


        public ICollection<ProductAuthor> ProductAuthors { get; set; }

        public ICollection<ProductRate>? ProductRates { get; set; }
    }
}
