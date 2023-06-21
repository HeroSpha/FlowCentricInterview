using Microsoft.AspNetCore.Components;
using OnlineShop.Components.Components;
using Shared;

namespace OnlineShop.Components;

public partial class CartItem : WPComponentBase
{
    [Parameter]
    public CartItemDto Item { get; set; }

    [Parameter]
    public EventCallback<CartItemDto> RemoveFromCartClick { get; set; }

    [Parameter]
    public EventCallback<(CartItemDto, int)> AddToCartClick { get; set; }

    [Parameter]
    public EventCallback<CartItemDto> RemoveCartClick { get; set; }
    
    [Parameter] public string TotalItemCost { get; set; }

    private decimal CalculateItemTotal()
    {
        // Calculate item total here
        return 0.00m;
    }

    private Task OnRemoveFromCartClick()
    {
        return RemoveFromCartClick.InvokeAsync(Item);
    }

    private Task OnAddToCartClick(int quantity)
    {
        return AddToCartClick.InvokeAsync((Item, quantity));
    }

    private Task OnRemoveCartClick()
    {
        return RemoveCartClick.InvokeAsync(Item);
    }
}