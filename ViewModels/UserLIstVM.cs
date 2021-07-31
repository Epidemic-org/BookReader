using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class UserListVM
    {

        public int Id { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string Name { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string NBirthDate {
            get {
                return BirthDate.ToPersianDateTimeString();
            }

            set {
                BirthDate = value.ToEnglishDateTime();
            }
        }
        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string NationalCode { get; set; }
        public string Phone { get; set; }
        public int GenderType { get; set; }
        public int JobType { get; set; }
        public int IsAcceptRules { get; set; }
        public DateTime CreationDate { get; set; }
        public string NCreationDate {
            get {
                return CreationDate.ToPersianDateTimeString();
            }

            set {
                CreationDate = value.ToEnglishDateTime();
            }
        }
        public bool IsActive { get; set; }

    }
}
