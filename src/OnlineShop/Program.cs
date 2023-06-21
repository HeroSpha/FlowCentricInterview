using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
using OnlineShop;
using OnlineShop.Authentication;
using OnlineShop.Configurations;
using OnlineShop.Helpers;
using OnlineShop.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//var discountSettings = new DiscountSettings();
builder.Services.Configure<DiscountSettings>(options => builder.Configuration.GetSection(DiscountSettings.SectionName));
//builder.Configuration.GetSection(DiscountSettings.SectionName).Bind(discountSettings);
//builder.Services.AddSingleton(new DiscountSettings());

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddAuthorizationCore();
builder.Services.AddSingleton<IDiscountCalculator, DiscountCalculator>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationProvider>();

builder.Services.AddServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
