using OnlineShop.Services.Models;
using Shared;

namespace OnlineShop.Services;

public interface IOrderService
{
    OrderDto Prepare(IEnumerable<CartItemDto> cartItems, UserDto user, decimal salesValueExcl,  decimal appliedDiscount, decimal salesValueInc);
    Task Create(OrderDto order);
    Task<IEnumerable<OrderDto>> GetOrders();
    Task<OrderDto> GetOrderByIdAsync(long id);
}