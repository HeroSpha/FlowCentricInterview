using Microsoft.AspNetCore.Components;
using Shared;

namespace OnlineShop.Components;

public partial class PaymentOption
{
    [Parameter]
    public string Label { get; set; }

    [Parameter]
    public bool IsSelected { get; set; }

    [Parameter]
    public Enum Value { get; set; }
    
    [Parameter]
    public string GroupName { get; set; }

    [Parameter]
    public EventCallback<Enum> OnClick { get; set; }

    private async Task HandleClick()
    {
        if (!IsSelected)
        {
            IsSelected = true;
            await OnClick.InvokeAsync(Value);
        }
    }
}