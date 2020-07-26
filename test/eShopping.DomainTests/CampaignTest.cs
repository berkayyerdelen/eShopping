using eShopping.Domain;
using eShopping.Domain.ShoppingCart.Enums;
using eShopping.Domain.ShoppingCart.ValueObject;
using Xunit;

namespace eShopping.DomainTests
{
    public class CampaignTest
    {
        [Fact]
        public void Campaign_Should_Create_When_ParameterIsValid()
        {
            var campaign = new Campaign(new Category("testCategory"), 1, DiscountType.Rate, 1);
            Assert.Equal("testCategory", campaign.Category.Title);
            Assert.Equal(DiscountType.Rate, campaign.DiscountType);
            Assert.Equal(1, campaign.OrderedItemCount);
            Assert.Equal(1,campaign.DiscountValue);
        }

        [Fact]
        public void Campaign_Should_CreateWithZeroItem_When_ItemCountLessThanZero()
        {
            
            Assert.Throws<BusinessException>(() =>
            {
                var campaign = new Campaign(new Category("testCategory"), 1, DiscountType.Rate, -3);
            });
        }
    }
}