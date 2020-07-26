using System;

namespace eShopping.Domain.ShoppingCart.ValueObject
{
    public class Delivery:BaseEntity<Guid>
    {
        public double CostPerDelivery { get; set; }
        public double CostPerProduct { get; set; }
        public double FixedCost { get; set; }

        public Delivery(double costPerDelivery, double costPerProduct, double fixedCost)
        {
            CostPerDelivery = costPerDelivery;

            CostPerProduct = costPerProduct;

            FixedCost = fixedCost;
        }

        public double Calculate(Cart cart)
        {
            var categoryCount = cart.CategoryCount();

            var productCount = cart.GetProductCount();

            var calculatedDeliveryPrice = (CostPerDelivery * categoryCount) + (CostPerProduct * productCount) + FixedCost;

            return calculatedDeliveryPrice;
        }
    }
}