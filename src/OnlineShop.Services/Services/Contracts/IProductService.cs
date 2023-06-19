using OnlineShop.Services.Models;

namespace OnlineShop.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<ProductDto?> GetProductAsync(long productId);
    
}