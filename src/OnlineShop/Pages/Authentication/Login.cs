using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using OnlineShop.Configurations;
using OnlineShop.Models;
using OnlineShop.Services;
using OnlineShop.Services.Models;

namespace OnlineShop.Pages;

public partial class Login : ComponentBase
{
    private LoginModel user = new LoginModel();
    [Inject] public ILocalStorageService LocalStorage { get; set; }
    [Inject]public AuthenticationStateProvider AuthStateProvider { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    [Inject] public IUserService UserService { get; set; }
    private bool Invalid;

    private async void HandleLogin()
    {
        var loggedInUser = await UserService.Login(user.Username, user.Password);
        if (loggedInUser != null)
        {
            await LocalStorage.SetItemAsync<UserDto>(UserConfig.User, loggedInUser);
            await LocalStorage.SetItemAsync(UserConfig.UserId, loggedInUser.UserID);
            await AuthStateProvider.GetAuthenticationStateAsync();
            NavigationManager.NavigateTo("");
        }
        else
        {
            Invalid = true;
        }
       
    }
    private void HandleTextChanged(ChangeEventArgs e)
    {
        Invalid = false;
        StateHasChanged();
    }
    
}