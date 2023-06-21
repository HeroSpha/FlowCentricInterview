using Microsoft.AspNetCore.Components;

namespace OnlineShop.Shared;

public partial class NavMenu : LayoutComponentBase
{
    private bool collapseNavMenu = true;

    private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }
}