namespace InsideCase.Core.Schema.OrderSchema.ManageOrderSchema.Response
{
    public class OrderIdResponse
    {
        public OrderIdResponse(int order_Id)
        {
            Order_Id = order_Id;
        }

        public int Order_Id { get; set; }
    }
}
