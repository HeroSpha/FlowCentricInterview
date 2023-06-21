using OnlineShop.Services.Models;
using Shared;

namespace OnlineShop.Services;

public interface IOrderService
{
    OrderInput Prepare(IEnumerable<CartItemDto> cartItems, UserDto user, decimal salesValueExcl,  decimal appliedDiscount, decimal salesValueInc);
    Task Create(OrderInput order);
    Task<IEnumerable<OrderDto>> GetOrders();
    Task<IEnumerable<OrderDto>> GetUserOrders(long userId);
    Task<OrderDto> GetOrderByIdAsync(long id);
}