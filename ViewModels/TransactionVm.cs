using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class TransactionVm
    {
        public int Id { get; set; }
        
        public string BankName { get; set; }

        public string TrackingCode { get; set; }

        public decimal Amount { get; set; }

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
        public bool IsSuccess { get; set; }
        public string Description { get; set; }
    }
}
