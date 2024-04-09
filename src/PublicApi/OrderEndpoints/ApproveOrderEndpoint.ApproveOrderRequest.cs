using System.ComponentModel.DataAnnotations;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class ApproveOrderRequest : BaseRequest
{
    public int OrderId { get; init; }

    public ApproveOrderRequest(int orderId)
    {
        OrderId = orderId;
    }
}
