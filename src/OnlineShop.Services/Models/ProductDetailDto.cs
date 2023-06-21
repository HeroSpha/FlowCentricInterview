namespace OnlineShop.Services.Models;

public record ProductDetailDto(long OrderDetailsId, long OrderId, long ProductId, int Quantity);