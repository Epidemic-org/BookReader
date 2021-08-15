using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.ViewModels
{
    public class OrderItemGetVM
    {

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public string Title { get; set; }
        public string Pic { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public decimal? RateValue { get; set; }
        public string UserFullName { get; set; }

    }
}
