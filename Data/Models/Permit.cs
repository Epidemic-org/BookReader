using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Permit
    {
        public int Id { get; set; }
        public int TermTypeId { get; set; }
        public int AdminId { get; set; }
        public string Title { get; set; }
        public bool IsAcitve { get; set; }
        public int PermitType { get; set; }
        public string PermitBaseCode { get; set; }
        public int PermitStartNumber { get; set; }
        public int PermitCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreationDate { get; set; }        
        public TermType TermType { get; set; }
        public AppUser Admin { get; set; }        
        public ICollection<PermitGeneration> PermitGenerations { get; set; }
        public ICollection<PermitUser> PermitUsers { get; set; }
    }
}
