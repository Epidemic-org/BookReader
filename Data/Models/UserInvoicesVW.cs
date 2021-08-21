﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class vwUserInvoices
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Address { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
