using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Lib.Strategy
{
    public interface IPromotionStrategy
    {
        decimal Calculate();
    }
}
