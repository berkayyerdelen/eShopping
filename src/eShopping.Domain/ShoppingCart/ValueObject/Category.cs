using System;
using System.Collections.Generic;
using System.Linq;
using eShopping.Domain.ShoppingCart.Enums;

namespace eShopping.Domain.ShoppingCart.ValueObject
{
    public class Category : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public List<Product> Products{ get; set; }
        public Category ParentCategory { get; set; }

        public Category(string title)
        {
            Products= new List<Product>();
            Title = title;
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public double GetProductSumPrice()
        {
            return Products.Sum(x => x.Price);
        }

        public double GetBestDiscount(List<Campaign> campaigns)
        {
            var productCount = Products.Count;

            var productPriceSum = GetProductSumPrice();

            var bestCampaignForRate = campaigns.Where(x => x.Category.Title == Title  && x.DiscountType == DiscountType.Rate).OrderByDescending(x => x.DiscountValue).FirstOrDefault();

            var bestCampaignForRateDiscount = bestCampaignForRate?.GetCampaignDiscount(productPriceSum) ?? 0;

            var bestCampaignForPrice = campaigns.Where(x => x.Category.Title == Title &&  x.DiscountType == DiscountType.Amount).OrderByDescending(x => x.DiscountValue).FirstOrDefault();

            var bestCampaignForPriceDiscount = bestCampaignForPrice?.GetCampaignDiscount(productPriceSum) ?? 0;

            return bestCampaignForPriceDiscount >= bestCampaignForRateDiscount ? bestCampaignForPriceDiscount : bestCampaignForRateDiscount;
        }
    }
}