using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class AspNetUserLogins
    {
        // has relation to other tables, aspnetuser
        public string LogingProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplay { get; set; }
        [ForeignKey("1")]
        public int UserId { get; set; }

    }
}
