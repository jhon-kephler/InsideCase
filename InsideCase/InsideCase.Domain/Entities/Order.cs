using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Total_Amount { get; set; }
        public decimal Total_Price { get; set; }
        public bool Removed { get; set; }
        public bool Closed { get; set; }
        public DateTime Created_At { get; set; }
        public List<ProductOrder> ProductOrder { get; set; }
    }
}
