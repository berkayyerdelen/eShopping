using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eShopping.Domain.ShoppingCart.Enums;
using eShopping.Domain.ShoppingCart.ValueObject;

namespace eShopping.Domain.ShoppingCart
{
    public class Cart : AggregateRoot, ICartRepository
    {
        public List<Product> Products { get; private set; } = new List<Product>();
        private double TotalAmount
        {
            get
            {
                return Products.Sum(x => x.Price);
            }
        }

        public void AddProduct(Product product, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Products.Add(product);
            }
        }
        public int GetProductCount()
        {
            return Products.Count;
        }

        public double GetTotalAmountAfterDiscounts()
        {

            var campaignDiscountAmount = GetCampaignDiscount();

            var couponDiscountAmount = GetCouponDiscount();

            if (TotalAmount - campaignDiscountAmount - couponDiscountAmount<0)
            {
               throw new BusinessException("Total amount should be greather than 0");
            }
            return TotalAmount - campaignDiscountAmount - couponDiscountAmount;
        }

        public double GetCouponDiscount()
        {
           
            var coupon = new Coupon(10, DiscountType.Rate, 5);

            var couponDiscountPriceValue = coupon.GetCouponDiscount(TotalAmount);

            return couponDiscountPriceValue;
        }

        public double GetCampaignDiscount()
        {
            var campaings = new List<Campaign>()
            {
                new Campaign(new Category("Laptop"), 10, DiscountType.Rate,4),
                new Campaign(new Category("Watch"), 10, DiscountType.Amount,5),
                new Campaign(new Category("TV"), 10, DiscountType.Rate,2)
            };

            var categorisedProduct = GroupProductByCategory();

            var campaignValue = default(double);

            foreach (var category in categorisedProduct)
            {
                var bestDiscount = category.GetBestDiscount(campaings);

                campaignValue += bestDiscount;
            }

            return campaignValue;
        }

        public List<Category> GroupProductByCategory()
        {
            foreach (var item in Products)
            {
                item.Category.AddProduct(item);
            }

            var categories = Products.GroupBy(p => p.Category.Title)
                .Select(x =>
                    new Category(x.Key)
                    {
                        Products = x.ToList()
                    })
                .ToList();

            return categories;
        }


        public int CategoryCount()
        {
            return Products.GroupBy(p => p.Category.Title).Count();
        }

        public double GetDeliveryCost()
        {
            var delivery = new Delivery(5, 1, 3);

            var deliveryAmount = delivery.Calculate(this);

            return deliveryAmount;
        }
    }
}
