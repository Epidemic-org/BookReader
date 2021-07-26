using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }

        public int ParentId { get; set; }
        public int IsActive { get; set; }
        public double RateValue { get; set; }
        public ICollection<CommentLikes> CommentLikes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public User User { get; set; }
        public Comment Parent { get; set; }
        public Product Product { get; set; }
    }
}
