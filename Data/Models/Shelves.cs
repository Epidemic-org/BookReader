﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Shelves
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ShelfName { get; set; }
        public int IsGlobal { get; set; }
        public DateTime  CreationDate { get; set; }
        public User User { get; set; }
        public ICollection<UserShelves> UserShelves { get; set; }

    }

}
