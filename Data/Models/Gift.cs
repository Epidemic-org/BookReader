using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class Gift
    {
        public int Id { get; set; }
        public int GiftGiverId { get; set; }
        public int GiftRecipientId { get; set; }
        public int WalletLogId{ get; set; }
        public int InvoiceId { get; set; }
        public string GiftCode { get; set; }
        public DateTime RecieveDate { get; set; }
        public DateTime CreationDate { get; set; }

        public AppUser GiftGiver { get; set; }
        public AppUser GiftRecipient { get; set; }
        public WalletLog WalletLog { get; set; }
        public Invoice Invoice { get; set; }

    }
}
