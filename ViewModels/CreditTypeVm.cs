using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class CreditTypeVm
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        [Display (Name = ("عنوان"))]
        [Required (ErrorMessage = "این فیلد {0} اجباری است.")]
        public string Title { get; set; }
        [Display (Name = "توضیحات")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public decimal CreditPrice { get; set; }
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
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
