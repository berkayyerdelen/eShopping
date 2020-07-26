using System.Linq;
using eShopping.Domain.ShoppingCart;
using eShopping.Domain.ShoppingCart.ValueObject;
using Xunit;

namespace eShopping.DomainTests
{
    public class CartTest
    {
        [Fact]
        public void Cart_Should_Not_Null()
        {
            var cart = new Cart();
            Assert.NotNull(cart);
        }

        [Fact]
        public void Add_Product_ToCard()
        {
            var cart = new Cart();
            cart.AddProduct(new Product("test",5,new Category("testCategory")),4);
            Assert.Equal(4, cart.Products.Count);
        }

        [Fact]
        public void Cart_ShouldReturn_ProductCountInCart()
        {
            var cart = new Cart();
            Assert.False(cart.Products.Any());
            cart.AddProduct(new Product("test", 5, new Category("testCategory")), 4);
            Assert.Equal(4, cart.Products.Count);
        }

        [Fact]
        public void Cart_ShouldReturn_GroupProductByCategory()
        {
            var cart = new Cart();
            cart.AddProduct(new Product("test", 5, new Category("testCategory")), 4);
            cart.AddProduct(new Product("test", 5, new Category("testCategory")), 4);
            cart.AddProduct(new Product("test", 5, new Category("testCategory")), 4);
            cart.AddProduct(new Product("test2", 5, new Category("testCategory2")), 4);
            cart.AddProduct(new Product("test2", 5, new Category("testCategory2")), 4);
            cart.AddProduct(new Product("test2", 5, new Category("testCategory2")), 4);

            var categoryList = cart.GroupProductByCategory();
            Assert.Equal(2, categoryList.Count);
        }

        [Fact]
        public void Cart_ShouldReturn_CategoryCountInCart()
        {
            var cart = new Cart();
            cart.AddProduct(new Product("test",5,new Category("testCategory")),1 );
            cart.AddProduct(new Product("test", 5, new Category("testCategory")), 1);
            Assert.Equal(1,cart.CategoryCount());

            cart.AddProduct(new Product("test", 5, new Category("testCategory2")), 1);
            Assert.Equal(2, cart.CategoryCount());

        }

        [Fact]
        public void Cart_ShouldReturn_CouponDiscount()
        {
            var cart = new Cart();
            cart.AddProduct(new Product("test", 5, new Category("testCategory")), 1);
            cart.AddProduct(new Product("test2", 5, new Category("testCategory")), 1);
            Assert.Equal(0.5,cart.GetCouponDiscount());
        }

        [Fact]
        public void Cart_ShouldReturn_CapmpaignDiscount()
        {
            var cart = new Cart();

            cart.AddProduct(new Product("test", 5, new Category("Laptop")), 1);
            cart.AddProduct(new Product("test", 5, new Category("Watch")), 4);
            cart.AddProduct(new Product("test2", 5, new Category("Laptop")), 4);
            cart.AddProduct(new Product("test2", 5, new Category("Watch")), 1);

            var campaignDiscount = cart.GetCampaignDiscount();

            Assert.Equal(12.5, campaignDiscount);
        }

        [Fact]
        public void Cart_ShouldReturn_DeliveryCost()
        {
            var cart = new Cart();
            var deliveryCost = cart.GetDeliveryCost();
            Assert.Equal(3,deliveryCost);
            
        }
        
    }
}