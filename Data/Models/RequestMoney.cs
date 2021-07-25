using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class RequestMoney
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal AmountValue { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
