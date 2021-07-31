using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class CommentLike
    {
        public int Id{ get; set; }
        public int UserId { get; set; }        
        public int CommentId { get; set; }
        public bool IsLike { get; set; }
        public DateTime CreationDate { get; set; }
        public AppUser User { get; set; }
        public Comment Comment { get; set; }
    }
}
