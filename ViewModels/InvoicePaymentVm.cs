using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class InvoicePaymentVm
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
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