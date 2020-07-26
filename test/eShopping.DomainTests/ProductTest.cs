using eShopping.Domain.ShoppingCart.ValueObject;
using Xunit;

namespace eShopping.DomainTests
{
    public class ProductTest
    {
        [Fact]
        public void Product_ShouldCreate_Product()
        {
            var product  = new Product("test",20, new Category("testCategory"));
            Assert.Equal("test",product.Title);
            Assert.Equal(20,product.Price);
            Assert.Equal("testCategory",product.Category.Title);
        }
    }
}