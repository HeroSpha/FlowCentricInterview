using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using OnlineShop.Components.Components;
using OnlineShop.Configurations;
using OnlineShop.Services;
using OnlineShop.Services.Configurations;
using OnlineShop.Services.Models;

namespace OnlineShop.Pages.Orders;
[Authorize]
public partial class Orders : WPBaseComponent
{
    [Inject] public IOrderService OrderService { get; set; }
    [Inject] public ILocalStorageService LocalStorageService { get; set; }
    protected override bool ShouldRender()
    {
        return shouldRender;
    }

    private IEnumerable<OrderDto> _orders = new List<OrderDto>();

    protected override async Task OnInitializedAsync()
    {
        var userId = await LocalStorageService.GetItemAsync<long>(UserConfig.UserId);
        if (userId > 0)
        {
            var orders = await OrderService.GetUserOrders(userId);
            _orders = new List<OrderDto>(orders);
        }
        shouldRender = true;
    }
}