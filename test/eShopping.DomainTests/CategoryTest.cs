using System.Collections.Generic;
using eShopping.Domain;
using eShopping.Domain.ShoppingCart.Enums;
using eShopping.Domain.ShoppingCart.ValueObject;
using Xunit;

namespace eShopping.DomainTests
{
    public class CategoryTest
    {
        [Fact]
        public void Cart_Should_CreateCategory_With_Title()
        {
            var category = new Category("title");
            Assert.Equal("title", category.Title);
        }

        [Fact]
        public void Category_Should_AddProductCart()
        {
            var category = new Category("title");
            var product = new Product("testProduct", 100, category);
            category.AddProduct(product);
            category.AddProduct(product);
            Assert.Equal(2, category.Products.Count);

        }

        [Fact]
        public void Category_ShouldReturn_ProductSumPrice()
        {
            var category = new Category("title");
            var product = new Product("testProduct", 2, category);
            category.AddProduct(product);
            Assert.Equal(2, category.GetProductSumPrice());
        }

        [Fact]
        public void Category_ShouldReturn_BestDiscountForAmount_Exception()
        {
            var campaigns = new List<Campaign>()
            {
                new Campaign(new Category("testCategory"),101,DiscountType.Amount,2 ),
                new Campaign(new Category("testCategory2"),101,DiscountType.Amount,2 ),
                new Campaign(new Category("testCategory2"),10,DiscountType.Rate,2 )
            };
            var category = new Category("testCategory");
            var product = new Product("testProduct", 101, category);
            category.AddProduct(product);
            Assert.Throws<BusinessException>(() =>
            {
                var bestDiscount = category.GetBestDiscount(campaigns);
            });
        }

    }
}