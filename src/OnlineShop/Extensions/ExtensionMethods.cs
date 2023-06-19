namespace OnlineShop.Extensions;

public static class ExtensionMethods
{
    public static bool ContainsIgnoreCase(this string source, string value)
    {
        return source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
    }
}