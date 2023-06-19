using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using OnlineShop.Configurations;
using OnlineShop.Services.Models;

namespace OnlineShop.Shared;

public partial class User
{
    [Inject] public AuthenticationStateProvider State { get; set; }
    [Inject] public ILocalStorageService LocalStorage { get; set; }
    [Inject] public ISyncLocalStorageService SyncLocalStorage { get; set; }
    [Inject] public NavigationManager NavigationManager { get; set; }
    private async void Logout()
    {
         await  LocalStorage.RemoveItemAsync(UserConfig.UserId);
         await  LocalStorage.RemoveItemAsync(UserConfig.User);
        await State.GetAuthenticationStateAsync();
    }

    private void Login()
    {
        NavigationManager.NavigateTo("/login");
    }

    private string GetLoggedUser()
    {
        var userJson = SyncLocalStorage.GetItemAsString(UserConfig.User);
        return JsonConvert.DeserializeObject<UserDto>(userJson).Username;
    }
    
}