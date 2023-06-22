namespace OnlineShop.Services.Models;

public record OrderInput(
    long orderId,
    long userId, 
    string customerName, 
    DateTime orderDate, 
    decimal salesValueExcl, 
    decimal appliedDiscount, 
    decimal salesValueIncl,
    IEnumerable<OrderDetailInput> orderDetails);