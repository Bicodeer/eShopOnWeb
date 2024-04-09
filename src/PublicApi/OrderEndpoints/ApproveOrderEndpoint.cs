using System.Threading.Tasks;
using BlazorShared.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

/// <summary>
///  Approves Order
/// </summary>
public class ApproveOrderEndpoint : IEndpoint<IResult, ApproveOrderRequest, IRepository<Order>>
{

    public void AddRoute(IEndpointRouteBuilder app)
    {

        app.MapGet("api/approve-order/{orderId}", 
        async (int orderId, IRepository<Order> itemRepository) =>
        {
            return await HandleAsync(new ApproveOrderRequest(orderId), itemRepository);
        })
            .Produces<ApproveOrderResponse>()
            .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(ApproveOrderRequest request, IRepository<Order> itemRepository)
    {
        var response = new ApproveOrderResponse(request.CorrelationId());

        var order = await itemRepository.GetByIdAsync(request.OrderId);
        if (order == null)
        {
            return Results.NotFound();
        }
        order.UpdateStatus((int)OrderStatus.Approved);
        await itemRepository.UpdateAsync(order);
        response.Status = OrderStatus.Approved;
        return Results.Ok(response);
    }
}
