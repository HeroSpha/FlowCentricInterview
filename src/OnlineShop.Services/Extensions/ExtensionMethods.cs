using Flurl.Http;
using OnlineShop.Services.Configurations;

namespace OnlineShop.Services.Extensions;

public static class ExtensionMethods
{

    public static bool IsEqualTo(this string mainString, string value)
    {
        return string.Equals(mainString, value, StringComparison.OrdinalIgnoreCase);
    }
}