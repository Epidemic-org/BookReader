﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class CommentLikes
    {
        public int Id{ get; set; }
        [ForeignKey ("1")]
        public int UserId { get; set; }
        [ForeignKey ("2")]
        public int CommentId { get; set; }
        public int IsLike { get; set; }
        public DateTime CreationDate { get; set; }

    }

}
