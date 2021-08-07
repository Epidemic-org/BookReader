using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class ProductListVm
    {
        public int Id { get; set; }
        public int ProductCategoryId { get; set; }
        [Display(Name = "نام دسته بندی")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string CategoryName { get; set; }
        [Display(Name = "عنوان")]

        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string Title { get; set; }
        [Display(Name = "توضیحات")]

        public string Description { get; set; }
        [Display(Name = "برچسب ها")]
        public string Tags { get; set; }
        public int UserId { get; set; }
        [Display(Name = "نام و نام خانوادگی کاربر")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string UserFullName { get; set; }
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public DateTime CreationDate { get; set; }
        public string NCreationDate {
            get {
                return CreationDate.ToPersianDateTimeString();
            }

            set {
                CreationDate = value.ToEnglishDateTime();
            }
        }
        public DateTime? EditionDate { get; set; }

        [Display(Name = "نوع محصول")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public int ProductType { get; set; }

    }
}
