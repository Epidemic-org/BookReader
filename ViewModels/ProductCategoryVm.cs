using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class ProductCategoryVm
    {
        [Display(Name = "شناسه")]
        public int Id { get; set; }
        public int ParentId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "این فیلد {0} اجباری است.")]
        [StringLength(maximumLength: 50, MinimumLength = 10)]
        public string Name { get; set; }


        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public string Pic { get; set; }

        public IFormFile PicFile { get; set; }

        public string Icon { get; set; }
        public IFormFile IconFile { get; set; }

        public bool IsActive { get; set; }
        public int AdminId { get; set; }
        public DateTime CreationDate { get; set; }
        public string NCreationDate 
        {
            get
            {
                return CreationDate.ToPersianDateTimeString();
            }

            set {
                CreationDate = value.ToEnglishDateTime();
            }
        }
        public int ProductType { get; set; }

    }
}
