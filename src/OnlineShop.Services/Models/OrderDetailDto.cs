namespace OnlineShop.Services.Models;

public record OrderDetailDto(long ProductId, int Quantity)
{
    public long OrderID { get; init ; }
    public long OrderDetailID { get; init ; }
    public ProductDto Product { get; init; }
}