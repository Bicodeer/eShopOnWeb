using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Enums;
using BlazorShared.Models;

namespace BlazorShared.Interfaces;

public interface IOrderService
{
    Task<List<Order>> List();
    Task<Order> GetById(int orderId);
    Task<OrderStatus> Approve(int orderId);
}
