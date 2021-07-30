using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class ProductPriceVm
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPriceValue { get; set; }
        public DateTime StartDate { get; set; }
        public string NStartDate
        {
            get
            {
                return StartDate.ToPersianDateTimeString();
            }

            set
            {
                StartDate = value.ToEnglishDateTime();
            }
        }
        public DateTime? EndDate { get; set; }
        public string NEndDate
        {
            get
            {
                return EndDate.ToPersianDateTimeString();
            }

            set
            {
                EndDate = value.ToEnglishDateTime();
            }
        }
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
