using Flurl;
using Flurl.Http;
using OnlineShop.Services.Configurations;
using OnlineShop.Services.Helpers;
using OnlineShop.Services.Models;
using Shared;

namespace OnlineShop.Services.Services;

public class OrderService : IOrderService
{
    private readonly IDateTimeProvider DateTimeProvider;
    private readonly IWPCongigManager _configManager;

    public OrderService(IDateTimeProvider dateTimeProvider, IWPCongigManager congigManager)
    {
        DateTimeProvider = dateTimeProvider;
        _configManager = congigManager;
    }

    public OrderInput Prepare(IEnumerable<CartItemDto> cartItems, UserDto user, decimal salesValueExcl,  decimal appliedDiscount, decimal salesValueInc)
    {
        var add = _configManager.BaseAddress;
        var orderDetails = cartItems.Select(item => new OrderDetailInput(0,0,item.ProductId, item.Qty));
        return new OrderInput(0,user.UserId,  user.Username, DateTimeProvider.UtcNow, salesValueExcl, appliedDiscount, salesValueInc, orderDetails);
    }

    public async Task Create(OrderInput order)
    {
         await _configManager.BaseAddress
             .WithHeader(_configManager.ApiKeyName, _configManager.ApiKeyValue)
            .AppendPathSegment("Orders")
            .PostJsonAsync(order);
    }

    public async Task<IEnumerable<OrderDto>> GetOrders()
    {
        return await GetAllOrders();
    }

    private async Task<IEnumerable<OrderDto>> GetAllOrders()
    {
        var orders = await _configManager.BaseAddress
            .WithHeader(_configManager.ApiKeyName, _configManager.ApiKeyValue)
            .AppendPathSegment("Orders")
            .GetJsonAsync<IEnumerable<OrderDto>>();
        return orders;
    }


    public async Task<IEnumerable<OrderDto>> GetUserOrders(long userId)
    {
        var orders = await GetAllOrders();
        return orders.Where(x => x.UserId == userId);
    }

    public async Task<OrderDto> GetOrderByIdAsync(long id)
    {
        var order = await _configManager.BaseAddress
            .WithHeader(_configManager.ApiKeyName, _configManager.ApiKeyValue)
            .AppendPathSegment($"Orders/{id}")
            .GetJsonAsync<OrderDto>();
        return order;
    }
}