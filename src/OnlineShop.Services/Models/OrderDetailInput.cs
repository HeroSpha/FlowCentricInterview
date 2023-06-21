namespace OnlineShop.Services.Models;

public record OrderDetailInput(
    long OrderDetailsId, 
    long OrderId, 
    long ProductId,
    long Quantity,
    string Order);