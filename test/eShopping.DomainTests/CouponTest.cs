using eShopping.Domain.ShoppingCart.Enums;
using eShopping.Domain.ShoppingCart.ValueObject;
using Xunit;

namespace eShopping.DomainTests
{
    public class CouponTest
    {
        [Fact]
        public void Create_Coupon()
        {
            var coupon = new Coupon(5,DiscountType.Rate,1);
            Assert.Equal(1,coupon.DiscountRate);
            Assert.Equal(DiscountType.Rate,coupon.DiscountType);
            Assert.Equal(5, coupon.MinimumPrice);
        }

        [Fact]
        public void Coupon_ShouldReturn_CalculateWithUsedCoupon()
        {
            var coupen = new Coupon(100,DiscountType.Rate, 20);
            var couponDiscount = coupen.GetCouponDiscount(1000);
            Assert.Equal(200,couponDiscount);
        }
        [Fact]
        public void Coupon_Should_CalculatedWithoutUsedCoupon()
        {
            var coupon = new Coupon(1000, DiscountType.Amount, 20);
            var couponDiscount = coupon.GetCouponDiscount(1000);
            Assert.Equal(400, couponDiscount);
        }

        [Fact]
        public void Coupon_ShouldReturn_CouponDiscountTest()
        {
            var coupon = new Coupon(100,DiscountType.Rate,5);
            var couponDiscountPriceValue = coupon.GetCouponDiscount(200);
            Assert.Equal(10,couponDiscountPriceValue);
        }
    }
}