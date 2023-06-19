using Flurl.Http;
using OnlineShop.Services.Configurations;

namespace OnlineShop.Services.Extensions;

public static class ExtensionMethods
{
    public static FlurlClient WithApiKeyHeader(this FlurlClient client, string apiKey)
    {
        client.HttpClient.DefaultRequestHeaders.Add(AppConfig.ApiKeyName, apiKey);
        return client;
    }

    public static bool IsEqualTo(this string mainString, string value)
    {
        return string.Equals(mainString, value, StringComparison.OrdinalIgnoreCase);
    }
}