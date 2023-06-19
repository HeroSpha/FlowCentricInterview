using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using OnlineShop.Components.Components;
using OnlineShop.Components.Components.Button.Enums;

namespace OnlineShop.Components;

public partial class WPButton : WPComponentBase
{
    [Parameter] public string? Text { get; set; }
    /// <summary>
    /// Set icon on the left hand side of the text
    /// </summary>
    [Parameter] public string? Icon { get; set; }
    [Parameter] public ButtonStyle ButtonStyle { get; set; } = ButtonStyle.primary;
    
    [Parameter] public EventCallback OnClick { get; set; }
    [Parameter] public bool IsDisabled { get; set; }
   

    private string _buttonClasses => new CssBuilder()
        .AddClass("btn-primary", ButtonStyle == ButtonStyle.primary)
        .AddClass("btn-info", ButtonStyle == ButtonStyle.info)
        .AddClass("btn-warning", ButtonStyle == ButtonStyle.warning)
        .AddClass("btn-secondary", ButtonStyle == ButtonStyle.secondary)
        .AddClass("btn-outline-success", ButtonStyle == ButtonStyle.outlinesuccess)
        .AddClass("disabled", IsDisabled)
        .Build();
}