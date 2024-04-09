using System.Collections.Generic;
using System;
using BlazorShared.Enums;

namespace Microsoft.eShopWeb.PublicApi.OrderEndpoints;

public class OrderDto
{
    public int Id { get; set; }
    public string BuyerId { get; set; }
    public DateTimeOffset OrderDate { get; set; }
    public AddressDto ShipToAddress { get; set; }
    public List<OrderItemDto> OrderItems { get; set; }
    public OrderStatus Status { get; set; }
}


public class AddressDto
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}

public class OrderItemDto
{
    public int CatalogItemId { get; set; }
    public string ProductName { get; set; }
    public string PictureUri { get; set; }
    public decimal UnitPrice { get; set; }
    public int Units { get; set; }
}
