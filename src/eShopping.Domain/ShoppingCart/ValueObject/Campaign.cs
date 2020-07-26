using eShopping.Domain.ShoppingCart.Enums;

namespace eShopping.Domain.ShoppingCart.ValueObject
{
    public class Campaign : Discount
    {
        public Category Category { get;  set; }
        public double DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; }

        public Campaign(Category category, double discountValue, DiscountType discountType)
        {
            Category = category;
            DiscountType = discountType;
            DiscountValue = discountValue;
        }
        public double GetCampaignDiscount(double amount)
        {
            return Calculate(DiscountType, amount, DiscountValue);
        }

    }
}