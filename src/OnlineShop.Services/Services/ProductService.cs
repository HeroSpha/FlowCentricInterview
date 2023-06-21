using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OnlineShop.Services.Configurations;
using OnlineShop.Services.Models;

namespace OnlineShop.Services.Services;

public class ProductService : IProductService
{
    private readonly IWPCongigManager _configManager;

    public ProductService(IWPCongigManager configManager)
    {
        _configManager = configManager;
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var products = await 
            _configManager.BaseAddress
                .WithHeader(_configManager.ApiKeyName, _configManager.ApiKeyValue)
            .AppendPathSegment("Products")
            .GetJsonAsync<IEnumerable<ProductDto>>();
        return products;
    }

    public async Task<ProductDto?> GetProductAsync(long productId)
    {
        try
        {
            var product = await _configManager.BaseAddress
                .WithHeader(_configManager.ApiKeyName, _configManager.ApiKeyValue)
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