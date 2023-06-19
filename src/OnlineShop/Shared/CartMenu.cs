using Microsoft.AspNetCore.Components;
using OnlineShop.Components.Components;
using OnlineShop.Services;

namespace OnlineShop.Shared;

public partial class CartMenu : WPComponentBase, IDisposable
{
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IShoppingCartService ShoppingCartService { get; set; }
    private int shoppingCartItemCount = 0;
    protected override void OnInitialized()
    {
        ShoppingCartService.OnShoppingCartChanged += ShoppingCartChanged;
    }

    protected void ShoppingCartChanged(int totalQty)
    {
        shoppingCartItemCount = totalQty;
        StateHasChanged();
    }
    public void Dispose()
    {
        ShoppingCartService.OnShoppingCartChanged -= ShoppingCartChanged;
    }

    private void Navigate()
    {
        NavigationManager.NavigateTo("/shoppingCart");
    }
}