﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{

    public class LoginVM
    {        
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
