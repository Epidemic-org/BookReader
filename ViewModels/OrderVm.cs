using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class OrderVm
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Display(Name= "نام و نام خانوادگی")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string UserFullName { get; set; }
        [Display(Name = "تاریخ ثبت سفارش")]

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
        [Display(Name ="آدرس")]
        [StringLength(maximumLength: 50)]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string Address { get; set; }
    }
}
