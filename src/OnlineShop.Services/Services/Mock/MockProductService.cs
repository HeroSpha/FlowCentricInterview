using System.Reflection;
using Newtonsoft.Json;
using OnlineShop.Services.Models;

namespace OnlineShop.Services.Services.Mock;

public class MockProductService : IProductService
{
    private IEnumerable<ProductDto> _products;

    public MockProductService()
    {
        _products = new List<ProductDto>()
        {
            new ProductDto(1, "50 TV", "Audio Visual", 15000.0000m, new List<string>()),
            new ProductDto(2, "Hi-Fi", "Audio Visual", 1200.0000m, new List<string>()),
            new ProductDto(3, "Camping Table", "Outdoor", 2000.0000m, new List<string>()),
            new ProductDto(4, "Gas Braai", "Outdoor", 1200.0000m, new List<string>()),
            new ProductDto(5, "Tent", "Outdoor", 1200.0000m, new List<string>()),
        };
    }
    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        await Task.Delay(0);
        return _products;
    }

    public async Task<ProductDto?> GetProductAsync(long productId)
    {
        return await Task.FromResult(_products.FirstOrDefault(x => x.ProductId == productId));
    }
}