using PromotionEngine.Lib.Models;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Lib.Strategy
{
    public class CombineFixedPromotionStrategy : FixedPromotionStartegy
    {
        public CombineFixedPromotionStrategy(List<CartItem> carts, int noOfItemsCombineTo, decimal fixedPrice) : base(carts, noOfItemsCombineTo, fixedPrice)
        {
        }
        public override decimal Calculate()
        {
            decimal totalPrice = 0.0m;

            int noOfItemsInCart = Carts.Count;
            int min_Qty_item = Carts.Min(p => p.Qty);

            if (noOfItemsInCart > 1)
            {
                while (min_Qty_item > 0)
                {
                    totalPrice += FixedPrice;
                    min_Qty_item--;
                }
                var remainingCartItems = Carts.Where(p => p.Qty != Carts.Min(q => q.Qty)).ToList();
                foreach (CartItem c in remainingCartItems)
                {
                    totalPrice += c.Qty * c.Product.Price;
                }
            }
            else
            {
                foreach (CartItem c in Carts)
                {
                    totalPrice += c.Qty * c.Product.Price;
                }
            }

            return totalPrice;
        }
    }
}
