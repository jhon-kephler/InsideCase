using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Domain.Entities
{
    public class ProductOrder
    {
        public int Id { get; set; }
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public int Amount { get; set; }
        public DateTime Created_At { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
