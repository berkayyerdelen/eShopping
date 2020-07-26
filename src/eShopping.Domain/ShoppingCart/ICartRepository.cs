using System.Collections.Generic;
using eShopping.Domain.ShoppingCart.ValueObject;

namespace eShopping.Domain.ShoppingCart
{
    public interface ICartRepository
    {
        void AddProduct(Product product, int quantity);
        int GetProductCount();
        int CategoryCount();
        double GetTotalAmountAfterDiscounts();
        double GetCouponDiscount();
        double GetCampaignDiscount();
        double GetDeliveryCost();
        List<Category> GroupProductByCategory();
       
    }
}