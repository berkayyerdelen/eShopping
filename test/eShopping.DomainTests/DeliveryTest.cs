using eShopping.Domain.ShoppingCart;
using eShopping.Domain.ShoppingCart.ValueObject;
using Xunit;

namespace eShopping.DomainTests
{
    public class DeliveryTest
    {
        [Fact]
        public void Delivery_Should_CreateDelivery()
        {
            var delivery = new Delivery(5,5,5);
            Assert.Equal(5,delivery.CostPerDelivery);
            Assert.Equal(5,delivery.CostPerProduct);
            Assert.Equal(5,delivery.FixedCost);
        }

        [Fact]
        public void Delivery_Should_Calculate()
        {
            var delivery = new Delivery(1, 1, 1);
            var cart = new Cart();
            cart.AddProduct(new Product("testProduct",1,new Category("testCategory")),1);
            Assert.Equal(3,delivery.Calculate(cart)); 
        }
    }
}