using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Role
    {
        public int Id { get; set; }
        public int RoleType { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public Guid ConcurrencyStamp { get; set; }
        public ICollection<RoleClaim> RoleClaims { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }

    }
}
