using InsideCase.Core.Schema.ProductSchema.SearchProductSchema.Response;

namespace InsideCase.Core.Schema.OrderSchema.SearchOrderSchema.Response
{
    public class OrderResponse
    {
        public OrderResponse() { }

        public int Id { get; set; }
        public List<ProductResponse> Products { get; set; }
        public int Total_Amount { get; set; }
        public decimal Total_Price { get; set; }
        public bool Closed { get; set; }
    }
}
