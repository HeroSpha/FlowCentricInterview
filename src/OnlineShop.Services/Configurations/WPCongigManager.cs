using Microsoft.Extensions.Configuration;

namespace OnlineShop.Services.Configurations;

public class WPCongigManager : IWPCongigManager
{
    private readonly IConfiguration _configuration;

    public WPCongigManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string? BaseAddress => _configuration["AppConfig:BaseAddress"];
}