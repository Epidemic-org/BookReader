using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class AppUserToken:IdentityUserToken<int>
    {
        public AppUser User { get; set; }
    }
}
