using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{

    public class LoginVM
    {
        [Required]
        [NotMapped]
        public string UserName { get; set; }
        [Required]
        [NotMapped]
        public string Password { get; set; }
    }
}
