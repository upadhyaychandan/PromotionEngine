using PromotionEngine.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Lib.Strategy
{
    public abstract class FixedPromotionStartegy : IPromotionStrategy
    {
        protected List<CartItem> Carts { get; set; }
        protected int NoOfItemsCombineTo { get; set; }
        protected decimal FixedPrice { get; set; }
        protected FixedPromotionStartegy(List<CartItem> carts, int noOfItemsCombineTo, decimal fixedPrice)
        {
            Carts = carts;
            NoOfItemsCombineTo = noOfItemsCombineTo;
            FixedPrice = fixedPrice;
        }
        public abstract decimal Calculate();
    }
}
