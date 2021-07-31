using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class InvoicePaymentVm
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        [Display (Name = "مبلغ قابل پرداخت")]
        public decimal PayAmount { get; set; }
        public int TransactionId { get; set; }
        public DateTime CreationDate { get; set; }
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