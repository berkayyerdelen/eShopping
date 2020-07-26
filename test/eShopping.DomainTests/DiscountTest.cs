using eShopping.Domain.ShoppingCart.Enums;
using eShopping.Domain.ShoppingCart.ValueObject;
using Moq;
using Xunit;

namespace eShopping.DomainTests
{
    public class DiscountTest
    {
        public Mock<Discount> MockDiscount { get; set; }
        public DiscountTest()
        {
            MockDiscount = new Mock<Discount>();
        }

        [Fact]
        public void Discount_ShouldCalculate_When_DiscountType_Amount()
        {
            MockDiscount.Setup(x => x.Calculate(DiscountType.Amount, 100, 20)).Returns(20);
            var calculatedDiscount =MockDiscount.Object.Calculate(DiscountType.Amount, 100, 20);
            Assert.Equal(20, calculatedDiscount);
        }

        [Fact]
        public void Discount_ShouldCalculate_When_DiscountType_Rate()
        {
            MockDiscount.Setup(x => x.Calculate(DiscountType.Rate, 100, 20)).Returns(40);
            var calculatedDiscount = MockDiscount.Object.Calculate(DiscountType.Rate, 100, 20);
            Assert.Equal(40, calculatedDiscount);
        }

        [Fact]
        public void Discount_ShouldReturn_CalculateDiscount_WithRate()
        {
            MockDiscount.Setup(x => x.Calculate(DiscountType.Amount, 100, 20)).Returns(20);
            var calculatedDiscount = MockDiscount.Object.Calculate(DiscountType.Amount, 100, 20);
        }

    }
    
}