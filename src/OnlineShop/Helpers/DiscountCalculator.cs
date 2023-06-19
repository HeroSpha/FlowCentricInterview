using OnlineShop.Configurations;

namespace OnlineShop.Helpers;

public class DiscountCalculator : IDiscountCalculator
{
    public (decimal discountedCost, Discount appliedDiscount) CalculateDiscount(decimal totalCost, List<Discount> discounts)
    {
        decimal totalDiscount = 0;
        Discount appliedDiscount = null;

        foreach (var discount in discounts)
        {
            if (totalCost > discount.Amount && discount.Percent > (appliedDiscount?.Percent ?? 0))
            {
                decimal discountAmount = totalCost * (decimal)(discount.Percent / 100);
                totalDiscount = discountAmount;
                appliedDiscount = discount;
            }
        }

        decimal discountedCost = totalCost - totalDiscount;
        return (discountedCost, appliedDiscount);
    }
}