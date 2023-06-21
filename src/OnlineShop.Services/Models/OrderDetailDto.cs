namespace OnlineShop.Services.Models;

public record OrderDetailDto(long ProductId, int Quantity)
{
    public long OrderId { get; set ; }
    public long OrderDetailsId { get; set ; }
    public ProductDto Product { get; set; }
    public string Order { get; set; }
}