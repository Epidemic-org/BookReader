using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public AppUser User { get; set; }
        public AppRole Role { get; set; }

    }
}
