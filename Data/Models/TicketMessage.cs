using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Data.Models
{
    public class TicketMessage
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int AdminId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime SeenDate { get; set; }
        public User Admin { get; set; }
        public User User { get; set; }
        public Ticket Ticket { get; set; }
    }
}
