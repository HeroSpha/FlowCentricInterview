namespace OnlineShop.Services.Helpers;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}