using PromotionEngine.Lib.Models;
using System.Collections.Generic;

namespace PromotionEngine.Lib.Strategy
{
    public abstract class PercentagePromotionStrategy : IPromotionStrategy
    {
        protected decimal Discount { get; set; }
        protected List<CartItem> Carts { get; set; }
        protected PercentagePromotionStrategy(List<CartItem> carts, decimal discount)
        {
            Carts = carts;
            Discount = discount;
        }

        public abstract decimal Calculate();
    }
}
