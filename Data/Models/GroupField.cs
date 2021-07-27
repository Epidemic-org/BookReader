using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class GroupField
    {
        public int Id
        { get; set; }
        public string GroupName { get; set; }
        public int AdminId { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<Field> Fields { get; set; }
        public AppUser Admin { get; set; }

    }
}
