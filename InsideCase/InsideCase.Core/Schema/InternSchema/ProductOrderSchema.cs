using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Core.Schema.InternSchema
{
    public class ProductOrderSchema
    {
        public int Order_Id { get; set; }
        public int Product_Id { get; set; }
        public int Amount { get; set; }
    }
}
