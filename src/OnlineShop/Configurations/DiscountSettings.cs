namespace OnlineShop.Configurations;

public  class DiscountSettings
{
    public const string SectionName = "DiscountSettings";
    public IEnumerable<Discount> Discounts  { get; set; }
}