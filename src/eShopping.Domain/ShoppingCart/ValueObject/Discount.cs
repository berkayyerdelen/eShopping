using System;
using eShopping.Domain.ShoppingCart.Enums;

namespace eShopping.Domain.ShoppingCart.ValueObject
{
    public abstract class Discount : BaseEntity<Guid>
    {
        public virtual double Calculate(DiscountType discountType, double amount, double discountValue)
        {
            if (discountType == DiscountType.Rate)
            {
                if (discountValue > 100)
                    throw new BusinessException("Discount value less than or equal to 100");

                return amount * discountValue / 100;

            }
            if (discountType == DiscountType.Amount)
            {
                if (discountValue > 100)
                    throw new BusinessException("Discount value less than or equal to 100");

                return amount * discountValue * 2 / 100;

            }

            if (discountValue > amount)
                throw new BusinessException("Discount value less than or equal to total amount");

            return discountValue;
        }
    }
}