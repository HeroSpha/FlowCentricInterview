namespace OnlineShop.Services.Models;

public record ProductDetailDto(long OrderDetailsID, long OrderID, long ProductID, int Quantity);