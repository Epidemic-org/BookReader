using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookReader.Data.Models
{
    public class AppUserLogin:IdentityUserLogin<int>
    {
        public AppUser User { get; set; }
    }
}
