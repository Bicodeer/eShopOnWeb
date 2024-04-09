namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class GetByIdOrderDetailRequest : BaseRequest
{
    public int OrderId { get; init; }

    public GetByIdOrderDetailRequest(int orderId)
    {
        OrderId = orderId;
    }
}
