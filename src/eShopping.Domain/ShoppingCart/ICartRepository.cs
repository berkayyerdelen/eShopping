using eShopping.Domain.ShoppingCart.ValueObject;

namespace eShopping.Domain.ShoppingCart
{
    public interface ICartRepository
    {
        void AddProduct(Product product, int quantity);
    }
}