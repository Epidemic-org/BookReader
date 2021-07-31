using BookReader.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class InvoiceItemVm
    {
        public int Id { get; set; }
        public int InvoiceID { get; set; }
        [Display(Name = ("شناسه محصول"))]
        public int ProductId { get; set; }
        [Display(Name = "نام محصول")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public decimal Quantity { get; set; }
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public decimal Price { get; set; }
        [Display(Name = "؟؟")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public decimal TermAMount { get; set; }
        public decimal NTermAmount {
            get {
                return Price * Quantity;
            }
        }

    }
}
