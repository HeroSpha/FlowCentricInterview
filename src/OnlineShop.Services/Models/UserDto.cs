namespace OnlineShop.Services.Models;

public record UserDto(string Username, string Password, string Role)
{
    public long UserId { get; set; }
    public IEnumerable<OrderDto> Orders { get; set; }
};