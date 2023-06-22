namespace OnlineShop.Services.Models;

public record OrderDetailInput(
    long orderDetailsId, 
    long orderId, 
    long productId,
    long quantity);