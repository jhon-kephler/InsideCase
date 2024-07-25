using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name_Product { get; set; }
        public decimal Price { get; set; }
        public int? Stock { get; set; }
        public bool Removed { get; set; }
        public DateTime Created_At { get; set; }
        public ProductOrder ProductOrder { get; set; }
    }
}
