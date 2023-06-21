namespace OnlineShop.Services.Models;

public record OrderDto(
    long UserId,
    DateTime OrderDate,
    string CustomerName,
    decimal SalesValueExcl,
    decimal AppliedDiscount,
    decimal SalesValueIncl,
    
    IEnumerable<OrderDetailDto> OrderDetails)
{
    public long OrderId { get; set; }
    public UserDto? User { get; set; }
}