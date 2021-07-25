using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Field
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int GroupId { get; set; }
        public string FieldName { get; set; }
        public string FieldIcon { get; set; }
        public int FieldType { get; set; }
        public bool IsRequired { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsActive { get; set; }
        public bool IsGlobal { get; set; }
        public DateTime CreationDate { get; set; }
        public ICollection<User> Admins { get; set; }
        public GroupField GroupField { get; set; }
    }
}
