using PromotionEngine.Lib.Models;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Lib.Strategy
{
    public class NItemFixedPromotionStrategy : FixedPromotionStartegy
    {
        public NItemFixedPromotionStrategy(List<CartItem> carts, int noOfItemsCombineTo, decimal fixedPrice) : base(carts, noOfItemsCombineTo, fixedPrice)
        {

        }

        public override decimal Calculate()
        {
            decimal totalPrice = 0.0M;
            int currentQty = Carts.FirstOrDefault().Qty;
            while (currentQty > 0)
            {
                if (currentQty >= NoOfItemsCombineTo)
                {
                    totalPrice += FixedPrice;
                    currentQty -= NoOfItemsCombineTo;
                    continue;
                }
                totalPrice += Carts.FirstOrDefault().Product.Price;
                currentQty -= 1;
            }
            return totalPrice;
        }
    }
}
