using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class ScoreLog
    {
        public int Id { get; set; }
        public int ScoreId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int ScoreValue { get; set; }

        //ToDo : Score

        public User User { get; set; }
    }
}
