using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class AppRole : IdentityRole<int>
    {
        public int RoleType { get; set; }
        

       
        public ICollection<RolePermission> RolePermissions { get; set; }
        public ICollection<AppRoleClaim> AppRoleClaims { get; set; }
       
    }
}
