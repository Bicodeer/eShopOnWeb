using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

/// <summary>
/// Get a Order detail Item by Id
/// </summary>
public class OrderDetailGetByIdEndpoint : IEndpoint<IResult, GetByIdOrderDetailRequest, IRepository<Order>>
{
    private readonly IUriComposer _uriComposer;
    private readonly IMapper _mapper;

    public OrderDetailGetByIdEndpoint(IUriComposer uriComposer, IMapper mapper)
    {
        _uriComposer = uriComposer;
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/order-detail/{orderId}",
            async (int orderId, IRepository<Order> orderRepository) =>
            {
                return await HandleAsync(new GetByIdOrderDetailRequest(orderId), orderRepository);
            })
            .Produces<GetByIdOrderDetailResponse>()
            .WithTags("OrderEndpoints");
    }

    public async Task<IResult> HandleAsync(GetByIdOrderDetailRequest request, IRepository<Order> orderRepository)
    {
        var response = new GetByIdOrderDetailResponse(request.CorrelationId());

        var spec = new OrderWithItemsByIdSpec(request.OrderId);
        var order = await orderRepository.FirstOrDefaultAsync(spec);
        if (order is null)
            return Results.NotFound();

        response.OrderDetail = _mapper.Map<OrderDto>(order);
        response.OrderDetail.OrderItems.ForEach(orderItem => orderItem.PictureUri = _uriComposer.ComposePicUri(orderItem.PictureUri));
        return Results.Ok(response.OrderDetail);
    }
}
