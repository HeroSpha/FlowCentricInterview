using Microsoft.AspNetCore.Components;
using OnlineShop.Services;
using OnlineShop.Services.Models;
using Shared;

namespace OnlineShop.Pages.ProductDetails;

public partial class DisplayProductDetails : WPBaseComponent
{
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IShoppingCartService ShoppingCartService { get; set; }
    [Inject] public IProductService ProductService { get; set; }
    [Parameter]public long ProductId { get; set; }
    private int Quantity = 1;
    public ProductDto Product { get; set; }
    protected override async Task OnInitializedAsync()
    {
        try
        {
            Product = await ProductService.GetProductAsync(ProductId);
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
        }
    }

    private void AddToCart_Click(CartItemDto cartItem)
    {
        ShoppingCartService.AddItem(cartItem, Quantity);
        NavigationManager.NavigateTo("/shoppingCart");
    }
}