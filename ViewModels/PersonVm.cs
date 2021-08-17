using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string NationalCode { get; set; }
        public string Phone { get; set; }
    }
}
