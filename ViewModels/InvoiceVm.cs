using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class InvoiceVm
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PermitGenerationId { get; set; }

        [Display(Name = "مجموع هزینه")]
        public decimal TotalAmount { get; set; }

        public decimal TotalTerms { get; set; }

        [Display(Name = "مبلغ قابل پرداخت")]
        public decimal PayableAmount { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        public DateTime CreationDate { get; set; }


        [Display(Name = "تاریخ شمسی")]
        public string NCreationDate
        {
            get
            {
                return CreationDate.ToPersianDateTimeString();
            }

            set
            {
                CreationDate = value.ToEnglishDateTime();
            }
        }

    }
}
