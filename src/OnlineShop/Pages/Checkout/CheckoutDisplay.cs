using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Flurl.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using OnlineShop.Components;
using OnlineShop.Configurations;
using OnlineShop.Services;
using OnlineShop.Services.Models;
using Shared;

namespace OnlineShop.Pages.Checkout;
[Authorize]
public partial class CheckoutDisplay : CartCalculator
{
    private bool IsDebitSelected { get; set; }
    private bool IsPaypalSelected { get; set; }
    private bool IsEftSelected { get; set; }

    private IEnumerable<CartItemDto> shoppingCartItems;
    [Inject] public IShoppingCartService ShoppingCartService { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IOrderService OrderService { get; set; }
    [Inject] public ILocalStorageService LocalStorage { get; set; }
    protected override void OnInitialized()
    {
        shoppingCartItems = ShoppingCartService.GetItems();
        CheckoutSummary();
        IsEftSelected = true;
        if (!shoppingCartItems.Any())
        {
            NavigationManager.NavigateTo("/");
        }
    }

    private void CheckoutSummary()
    {
        TotalQty =  shoppingCartItems.Sum(cartItem => cartItem.Qty);
        TotalCostDiscounted = TotalDiscountedCartCost(shoppingCartItems);
        TotalCost = TotalCartCost(shoppingCartItems);
        CanCheckout = shoppingCartItems.Any();
        ShoppingCartService.RaiseEventOnShoppingCartChanged(TotalQty);
    }

    private PaymentMethodEnum SelectedPaymentMethod { get; set; }

    private bool IsSelected(PaymentMethodEnum paymentMethod) => SelectedPaymentMethod == paymentMethod;

    private async Task SelectPaymentMethod(PaymentMethodEnum paymentMethod)
    {
        if (SelectedPaymentMethod != paymentMethod)
        {
            SelectedPaymentMethod = paymentMethod;
            await OnClick.InvokeAsync(SelectedPaymentMethod);
        }
    }
    [Parameter]
    public EventCallback<PaymentMethodEnum> OnClick { get; set; }

    private async void Checkout()
    {
        try
        {
            var user = await LocalStorage.GetItemAsync<UserDto>(UserConfig.User);
            if (user == null || !shoppingCartItems.Any()) return;
            var order = OrderService.Prepare(shoppingCartItems, user, SalesValueExcl, DiscountAmount, SalesValueIncl);
            await OrderService.Create(order);
            ShoppingCartService.Clear();
            CheckoutSummary();
            NavigationManager.NavigateTo("/");
        }
        catch (Exception e)
        {
            ErrorMessage = "An error occured, try again later.";
            StateHasChanged();
        }
    }

}