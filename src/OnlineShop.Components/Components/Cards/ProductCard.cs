using Microsoft.AspNetCore.Components;
using OnlineShop.Components.Components;

namespace OnlineShop.Components;

public partial class ProductCard : WPComponentBase
{
    
    [Parameter] public string? ProductName { get; set; }
    [Parameter] public string? CategoryName { get; set; }
    [Parameter] public decimal UnitPrice { get; set; }
    [Parameter] public long ProductId  { get; set; }
    [Parameter] public EventCallback OnClick { get; set; }
}