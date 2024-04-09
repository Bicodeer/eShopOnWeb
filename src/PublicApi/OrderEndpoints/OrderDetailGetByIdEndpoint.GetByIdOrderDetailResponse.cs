using System;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class GetByIdOrderDetailResponse : BaseResponse
{
    public GetByIdOrderDetailResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GetByIdOrderDetailResponse()
    {
    }

    public OrderDto OrderDetail { get; set; }
}
