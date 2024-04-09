using BlazorShared.Enums;

namespace BlazorShared.Models;

public class ApproveOrderResponse
{
    public OrderStatus Status { get; set; } = OrderStatus.Approved;
}
