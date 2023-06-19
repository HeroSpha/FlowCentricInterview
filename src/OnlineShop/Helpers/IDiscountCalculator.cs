using OnlineShop.Configurations;

namespace OnlineShop.Helpers;

public interface IDiscountCalculator
{
    (decimal discountedCost, Discount appliedDiscount) CalculateDiscount(decimal totalCost, List<Discount> discounts);
}