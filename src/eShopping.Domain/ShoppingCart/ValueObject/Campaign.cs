using eShopping.Domain.ShoppingCart.Enums;

namespace eShopping.Domain.ShoppingCart.ValueObject
{
    public class Campaign : Discount
    {
        public Category Category { get;  set; }
        public double DiscountValue { get; set; }
        public DiscountType DiscountType { get; set; }
        public int OrderedItemCount { get; set; }

        public Campaign(Category category, double discountValue, DiscountType discountType, int orderedItemCount)
        {
            if (orderedItemCount<0)
            {
                throw new BusinessException("Ordered item count should be greather than 0");
            }
            Category = category;
            DiscountType = discountType;
            DiscountValue = discountValue;
            OrderedItemCount = orderedItemCount;
        }
        public double GetCampaignDiscount(double amount)
        {
            return Calculate(DiscountType, amount, DiscountValue);
        }

    }
}