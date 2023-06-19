using Flurl;
using Flurl.Http;
using OnlineShop.Services.Configurations;
using OnlineShop.Services.Extensions;
using OnlineShop.Services.Models;

namespace OnlineShop.Services.Services;

public class UserService : IUserService
{
    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        return await GetUsers();
    }

    private static async Task<IEnumerable<UserDto>> GetUsers()
    {
        var users = await AppConfig.BaseAddress
            .WithHeader(AppConfig.ApiKeyName, AppConfig.ApiKeyValue)
            .AppendPathSegment("Users")
            .GetJsonAsync<IEnumerable<UserDto>>();
        return users;
    }

    public async Task<UserDto> GetUserByIdAsync(long id)
    {
        var user = await AppConfig.BaseAddress
            .WithHeader(AppConfig.ApiKeyName,AppConfig.ApiKeyValue)
            .AppendPathSegment($"Users/{id}")
            .GetJsonAsync<UserDto>();
        return user;
    }

    public async Task Create(UserDto userInput)
    {
        var user = await AppConfig.BaseAddress
            .WithHeader(AppConfig.ApiKeyName,AppConfig.ApiKeyValue)
            .AppendPathSegment("Users")
            .PostJsonAsync(userInput);
    }

    public async Task<UserDto?> Login(string username, string password)
    {
        var users = await GetUsers();
        var userDtos = users as UserDto[] ?? users.ToArray();
        if (userDtos.Any())
        {
            var user = userDtos.FirstOrDefault(user => user.Username.IsEqualTo(username) && user.Password == password);
            return user ?? default(UserDto);
        }
        else
        {
            return default(UserDto);
        }
    }
}