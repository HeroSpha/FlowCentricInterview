namespace OnlineShop.Services.Configurations;

public interface IWPCongigManager
{
    string? BaseAddress { get; }
    string? ApiKeyName { get; }
    string? ApiKeyValue { get; }
}