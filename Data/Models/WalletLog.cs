using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class WalletLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TransactionId { get; set; }
        public decimal WalletValue { get; set; }
        public DateTime CreationDate { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        //TODO: transcation model is needed here
    }
}
