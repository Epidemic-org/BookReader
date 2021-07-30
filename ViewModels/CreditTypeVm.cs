using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class CreditTypeVm
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal CreditPrice { get; set; }
        public decimal CreditAmount { get; set; }
        public bool IsActive { get; set; }
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
