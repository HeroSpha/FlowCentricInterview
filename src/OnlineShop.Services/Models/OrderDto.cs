namespace OnlineShop.Services.Models;

public record OrderDto(
    long UserID,
    DateTime OrderDate,
    string CustomerName,
    decimal SalesValueExcl,
    decimal AppliedDiscount,
    decimal SalesValueIncl,
    
    IEnumerable<OrderDetailDto> OrderDetails)
{
    public long OrderID { get; init; }
    public UserDto User { get; set; }
}