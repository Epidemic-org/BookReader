using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class WalletLogVm
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Display(Name = "نام و نام خانوادگی کاربر")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string UserFullName { get; set; }

        public int TransactionId { get; set; }
        public decimal WalletValue { get; set; }
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
        public string Description { get; set; }
    }
}
