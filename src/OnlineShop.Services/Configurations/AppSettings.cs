namespace OnlineShop.Services.Configurations;

public  class AppSettings
{
    public const string SectionName = "AppConfig";
    public  string BaseAddress { get; set; }
    public  string ApiKeyName  { get; set; }
    public   string ApiKeyValue { get; set; }
}