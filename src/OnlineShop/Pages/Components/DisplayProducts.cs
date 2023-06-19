using Microsoft.AspNetCore.Components;
using OnlineShop.Services.Models;


namespace OnlineShop.Pages.Components;

public partial class DisplayProducts : ComponentBase
{
    [Parameter]public IEnumerable<ProductDto> Products { get; set; }

    
}