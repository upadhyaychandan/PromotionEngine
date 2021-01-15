using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Lib.Models
{
    public class Product
    {
        public char SKU { get; set; }
        public decimal Price { get; set; }
        public Promotion Promotion { get; set; }
        public decimal FixedPrice { get; set; }
    }
}
