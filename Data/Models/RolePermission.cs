using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class RolePermission
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public int RoleId { get; set; }
    }
}
