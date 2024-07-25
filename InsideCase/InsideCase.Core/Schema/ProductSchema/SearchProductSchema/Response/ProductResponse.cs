using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Response
{
    public class ProductResponse
    {
        public ProductResponse() { }

        public int Id { get; set; }
        public string Nome_Produto { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public DateTime Data_Criacao { get; set; }
    }
}
