using OnlineShop.Services.Models;

namespace OnlineShop.Services;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
    Task<UserDto> GetUserByIdAsync(long id);
    Task Create(UserDto userInput);
    Task<UserDto?> Login(string username, string password);
}