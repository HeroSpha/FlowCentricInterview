using Microsoft.AspNetCore.Components;
using OnlineShop.Services;
using OnlineShop.Services.Models;
using OnlineShop.Services.Services;
using Shared;

namespace OnlineShop.Pages.ShopppingCart;

public partial class ShoppingCartDisplay : CartCalculator
{
    
    [Inject] public NavigationManager? NavigationManager { get; set; }

    [Inject] public IShoppingCartService ShoppingCartService { get; set; }
    private IEnumerable<CartItemDto> shoppingCartItems;

    protected override bool ShouldRender()
    {
        return shouldRender;
    }

    protected async override Task OnInitializedAsync()
    {
        try
        {
            shoppingCartItems = ShoppingCartService.GetItems();
            CartChanged();
            shouldRender = true;
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
        }
    }

    private void AddToCart_Click(CartItemDto cartItem, int qty)
    {
        ShoppingCartService.AddItem(cartItem, qty);
        CartChanged();
    }
    private void RemoveFromCart_Click(CartItemDto cartItem)
    {
        ShoppingCartService.RemoveItem(cartItem);
        CartChanged();
    }
    
    private void RemoveCart_Click(long id)
    {
        ShoppingCartService.RemoveItem(id);
        CartChanged();
    }

    
    
    private void CalculateCartSummary()
    {
        TotalQty =  shoppingCartItems.Sum(cartItem => cartItem.Qty);
        TotalCost = TotalCartCost(shoppingCartItems);
        CanCheckout = shoppingCartItems.Any();
    }
    private void CartChanged()
    {
        CalculateCartSummary();
        ShoppingCartService.RaiseEventOnShoppingCartChanged(TotalQty);
    }

    private void Checkout()
    {
        NavigationManager?.NavigateTo("/Checkout");
    }

    private void ContinueShopping()
    {
        NavigationManager?.NavigateTo("");
    }
    
}