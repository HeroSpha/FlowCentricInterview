using Flurl;
using Flurl.Http;
using OnlineShop.Services.Configurations;
using OnlineShop.Services.Models;

namespace OnlineShop.Services.Services;

public class ProductService :IProductService
{
    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var products = await AppConfig.BaseAddress
            .WithHeader(AppConfig.ApiKeyName,AppConfig.ApiKeyValue)
            .AppendPathSegment("Products")
            .GetJsonAsync<IEnumerable<ProductDto>>();
        return products;
    }

    public async Task<ProductDto?> GetProductAsync(long productId)
    {
        try
        {
            var product = await AppConfig.BaseAddress
                .WithHeader(AppConfig.ApiKeyName,AppConfig.ApiKeyValue)
                .AppendPathSegment($"Products/{productId}")
                .GetJsonAsync<ProductDto>();
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}