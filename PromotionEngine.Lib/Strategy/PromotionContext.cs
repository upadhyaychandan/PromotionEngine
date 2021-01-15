namespace PromotionEngine.Lib.Strategy
{
    public class PromotionContext
    {
        private IPromotionStrategy _promotionStrategy;
        public PromotionContext(IPromotionStrategy promotionStrategy)
        {
            _promotionStrategy = promotionStrategy;
        }
        public void SetStrategy(IPromotionStrategy promotionStrategy)
        {
            _promotionStrategy = promotionStrategy;
        }
        public decimal Calculate()
        {
            return _promotionStrategy.Calculate();
        }
    }
}
