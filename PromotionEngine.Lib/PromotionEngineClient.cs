using PromotionEngine.Lib.Models;
using PromotionEngine.Lib.Strategy;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Lib
{
    public class PromotionEngineClient : IPromotionEngine
    {
        public List<Product> Products { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<CartItem> CartItems { get; set; }
        public PromotionEngineClient(List<Product> products, List<Promotion> promotions, List<CartItem> cartItems)
        {
            this.Products = products;
            this.Promotions = promotions;
            this.CartItems = cartItems;
        }
        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0.0m;
            var nItemFixedItems = CartItems.Where(p => p.Product.Promotion.PromotionType.Equals("NItemFixed")).ToList();
            var combineFixedItems = CartItems.Where(p => p.Product.Promotion.PromotionType.Equals("CombineFixed")).ToList();
            IPromotionStrategy promotionStrategy;
            PromotionContext promotionContext;
            foreach (CartItem ci in nItemFixedItems)
            {
                promotionStrategy = new NItemFixedPromotionStrategy(new List<CartItem>() { ci }, ci.Product.Promotion.NoItemsCombined, ci.Product.FixedPrice);
                promotionContext = new PromotionContext(promotionStrategy);
                totalPrice += promotionContext.Calculate();
            }
            promotionStrategy = new CombineFixedPromotionStrategy(combineFixedItems, CartItems[0].Product.Promotion.NoItemsCombined, combineFixedItems[0].Product.FixedPrice);
            promotionContext = new PromotionContext(promotionStrategy);
            totalPrice += promotionContext.Calculate();
            return totalPrice;
        }
    }
}
