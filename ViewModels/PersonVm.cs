using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class PersonVm
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string NBirthDate
        {
            get
            {
                return BirthDate.ToPersianDateTimeString();
            }

            set
            {
                BirthDate = value.ToEnglishDateTime();
            }
        }
        public string NationalCode { get; set; }
        public string Pic { get; set; }
        public string Phone { get; set; }
        public int GenderType { get; set; }
        public int JobType { get; set; }
        public int IsAcceptRules { get; set; }
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
