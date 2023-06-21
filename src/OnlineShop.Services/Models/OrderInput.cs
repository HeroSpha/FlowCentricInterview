namespace OnlineShop.Services.Models;

public record OrderInput(
    long UserId, 
    string CustomerName, 
    DateTime OrderDate, 
    decimal SalesValueExcl, 
    decimal AppliedDiscount, 
    decimal SalesValueIncl,
    IEnumerable<OrderDetailInput> OrderDetails);