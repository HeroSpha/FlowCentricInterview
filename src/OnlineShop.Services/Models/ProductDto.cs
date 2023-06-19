namespace OnlineShop.Services.Models;

public record ProductDto(long ProductId, string ProductName, string CategoryName, decimal UnitPrice, IEnumerable<string> OrderDetails);