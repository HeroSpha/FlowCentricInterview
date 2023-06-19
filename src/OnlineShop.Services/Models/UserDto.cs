namespace OnlineShop.Services.Models;

public record UserDto(string Username, string Password, string Role)
{
    public long UserID { get; init; }
    public IEnumerable<OrderDto> Orders { get; init; }
};