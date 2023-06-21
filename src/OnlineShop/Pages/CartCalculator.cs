using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Components;
using OnlineShop.Configurations;
using OnlineShop.Helpers;
using OnlineShop.Services.Models;
using Shared;

namespace OnlineShop.Pages;

public class CartCalculator : WPBaseComponent
{
    protected int TotalQty = 0;
    protected decimal TotalCostDiscounted = 0m;
    protected decimal TotalCost = 0m;
    protected bool CanCheckout = false;
    protected decimal SalesValueExcl = 0;
    protected decimal SalesValueIncl { get; set; }
    protected Discount AppliedDiscount { get; set; }
    protected decimal DiscountAmount = 0;
    [Inject] IConfiguration  Configuration { get; set; }
    [Inject] public IDiscountCalculator DiscountCalculator { get; set; }
    protected decimal CalculateItemTotal(CartItemDto cartItem)
    {
        return cartItem.UnitPrice * cartItem.Qty;
    }
    protected decimal TotalDiscountedCartCost(IEnumerable<CartItemDto> shoppingCartItems)
    {
        var discountSetting = new DiscountSettings();
        Configuration.Bind(DiscountSettings.SectionName, discountSetting);
        var total = shoppingCartItems.Sum(cartItem => cartItem.Qty * cartItem.UnitPrice);
        var discountedCost = DiscountCalculator.CalculateDiscount(total, discountSetting.Discounts.ToList());

        DiscountAmount = total - discountedCost.discountedCost;
        SalesValueIncl = discountedCost.discountedCost;
        SalesValueExcl = discountedCost.discountedCost;
        AppliedDiscount = discountedCost.appliedDiscount;
        return discountedCost.discountedCost;
    }
    protected decimal TotalCartCost(IEnumerable<CartItemDto> shoppingCartItems)
    {
        
        return shoppingCartItems.Sum(cartItem => cartItem.Qty * cartItem.UnitPrice);
        
    }

    
}