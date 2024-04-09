using System;
using BlazorShared.Enums;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class ApproveOrderResponse : BaseResponse
{
    public ApproveOrderResponse(Guid correlationId) : base(correlationId)
    {
    }

    public ApproveOrderResponse()
    {
    }

    public OrderStatus Status { get; set; }
}
