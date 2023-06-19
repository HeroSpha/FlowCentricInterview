using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using OnlineShop.Configurations;
using OnlineShop.Services;

namespace OnlineShop.Authentication;

public class CustomAuthenticationProvider : AuthenticationStateProvider
{
    private readonly ILocalStorageService _localStorageService;
    private readonly IUserService _userService;

    public CustomAuthenticationProvider(ILocalStorageService localStorageService, IUserService userService)
    {
        _localStorageService = localStorageService;
        _userService = userService;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var state = new AuthenticationState(new ClaimsPrincipal());
        var userId = await _localStorageService.GetItemAsStringAsync(UserConfig.UserId);
        if (!string.IsNullOrEmpty(userId))
        {
            var user = await _userService.GetUserByIdAsync(long.Parse(userId));
            if(user != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role)
                }, "password-auth");
                state = new AuthenticationState(new ClaimsPrincipal(identity));
            }
        }
        NotifyAuthenticationStateChanged(Task.FromResult(state));
        return state;
    }
}