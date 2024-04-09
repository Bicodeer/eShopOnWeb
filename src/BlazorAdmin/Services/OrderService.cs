using BlazorShared.Enums;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorAdmin.Services;

public class OrderService : IOrderService
{
    private readonly HttpService _httpService;
    private readonly ILogger<OrderService> _logger;

    public OrderService(HttpService httpService, ILogger<OrderService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<List<Order>> List()
    {
        _logger.LogInformation("Fetching orders from API.");
        var response = await _httpService.HttpGet<PagedOrderResponse>($"orders");
        return response.Orders;
    }

    public async Task<Order> GetById(int orderId)
    {
        _logger.LogInformation("Fetching order detail from API.");
        var response = await _httpService.HttpGet<Order>($"order-detail/{orderId}");
        return response;
    }


    public async Task<OrderStatus> Approve(int orderId)
    {
        var response = await _httpService.HttpGet<ApproveOrderResponse>($"approve-order/{orderId}");
        return response.Status;
    }
}
