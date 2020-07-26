using eShopping.Domain.ShoppingCart.Enums;

namespace eShopping.Domain.ShoppingCart.ValueObject
{
    public class Coupon : Discount
    {
        public double MinimumPrice { get; set; }
        public DiscountType DiscountType { get; set; }
        public double DiscountRate { get; set; }

        public Coupon(double minimumPrice, DiscountType discountType, double discountRate)
        {
            MinimumPrice = minimumPrice;
            DiscountType = discountType;
            DiscountRate = discountRate;

        }

        public double GetCouponDiscount(double cartTotal)
        {
            return Calculate(DiscountType, cartTotal, DiscountRate);
        }

    }
}