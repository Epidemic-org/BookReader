﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ProductPublishers
    {
        public int Id { get; set; }
        [ForeignKey ("1")]
        public int ProductId { get; set; }
        [ForeignKey ("2")]
        public int PublisherId { get; set; }
        public decimal PublisherWagePercent{ get; set; }


    }
}