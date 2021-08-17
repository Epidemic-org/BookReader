using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class CommentVmPost
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Text { get; set; }



    }
}
