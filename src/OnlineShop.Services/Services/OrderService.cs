using Flurl;
using Flurl.Http;
using OnlineShop.Services.Configurations;
using OnlineShop.Services.Helpers;
using OnlineShop.Services.Models;
using Shared;

namespace OnlineShop.Services.Services;

public class OrderService : IOrderService
{
    public readonly IDateTimeProvider DateTimeProvider;
    private readonly IWPCongigManager _congigManager;

    public OrderService(IDateTimeProvider dateTimeProvider, IWPCongigManager congigManager)
    {
        DateTimeProvider = dateTimeProvider;
        _congigManager = congigManager;
    }

    public OrderDto Prepare(IEnumerable<CartItemDto> cartItems, UserDto user, decimal salesValueExcl,  decimal appliedDiscount, decimal salesValueInc)
    {
        var add = _congigManager.BaseAddress;
        var orderDetails = cartItems.Select(item => new OrderDetailDto(item.ProductId, item.Qty));
        return new OrderDto(user.UserID, DateTimeProvider.UtcNow, user.Username, salesValueExcl, appliedDiscount, salesValueInc, orderDetails);
    }

    public async Task Create(OrderDto order)
    {
        var response = await AppConfig.BaseAddress
            .WithHeader(AppConfig.ApiKeyName,AppConfig.ApiKeyValue)
            .AppendPathSegment("Orders")
            .PostJsonAsync(order);
    }

    public async Task<IEnumerable<OrderDto>> GetOrders()
    {
        var orders = await AppConfig.BaseAddress
            .WithHeader(AppConfig.ApiKeyName,AppConfig.ApiKeyValue)
            .AppendPathSegment("Orders")
            .GetJsonAsync<IEnumerable<OrderDto>>();
        return orders;
    }

    public async Task<OrderDto> GetOrderByIdAsync(long id)
    {
        var order = await AppConfig.BaseAddress
            .WithHeader(AppConfig.ApiKeyName,AppConfig.ApiKeyValue)
            .AppendPathSegment($"Orders/{id}")
            .GetJsonAsync<OrderDto>();
        return order;
    }
}