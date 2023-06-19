using OnlineShop.Services.Extensions;
using OnlineShop.Services.Models;

namespace OnlineShop.Services.Services.Mock;

public class MockUserService : IUserService
{
    private IEnumerable<UserDto> _users;

    public MockUserService()
    {
        _users = new List<UserDto>
        {
            new UserDto("Zane", "123@pass", "Admin"),
            new UserDto("Zane", "123@pass", "Admin"),
        };
    }
    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        return await Task.FromResult(_users);
    }

    public async Task<UserDto> GetUserByIdAsync(long id)
    {
        var user = _users.FirstOrDefault(x => x.UserID == id);
        return await Task.FromResult(user);
    }

   
    public async Task Create(UserDto userInput)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto?> Login(string username, string password)
    {
        var user = _users.FirstOrDefault(user => user.Password == password && user.Username.IsEqualTo(username));
        return await Task.FromResult(user);
    }
}