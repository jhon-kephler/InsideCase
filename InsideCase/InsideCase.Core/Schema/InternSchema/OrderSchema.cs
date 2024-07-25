using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Core.Schema.InternSchema
{
    public class OrderSchema
    {
        public OrderSchema() { }

        public OrderSchema(int id)
        {
            Id = id;
        }

        public OrderSchema(int total_Amount, decimal total_Price)
        {
            Total_Amount = total_Amount;
            Total_Price = total_Price;
        }

        public int Id { get; set; }
        public int Total_Amount { get; set; }
        public decimal Total_Price { get; set; }
    }
}
