using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class UserLogs
    {
        public int Id{ get; set; }
        [ForeignKey ("1")]
        public int UserId { get; set; }
        public DateTime CreationDate{ get; set; }
        public string UserIp { get; set; }
        public string UserDevice { get; set; }
        public int IsLogin { get; set; }
    }
}
