using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class PersonPostVM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Display(Name = "نام")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string FirstName { get; set; }
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string LastName { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        public string NationalCode { get; set; }
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "فرمت شماره تلفن وارد شده صحیح نمی باشد")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}
