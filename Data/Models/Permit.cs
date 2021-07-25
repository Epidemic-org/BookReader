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

        //TODO: term type model is needed here
        public User User { get; set; }
        public ICollection<PermitGeneration> PermitGenerations { get; set; }
    }
}
