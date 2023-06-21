using Flurl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Services.Configurations;
using OnlineShop.Services.Helpers;
using OnlineShop.Services.Services;
using OnlineShop.Services.Services.Mock;
using Flurl.Http;


namespace OnlineShop.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IWPCongigManager, WPCongigManager>();
        services.AddScoped<IProductService, ProductService>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IShoppingCartService, ShoppingCartService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IOrderService, OrderService>();
        return services;
    }
}