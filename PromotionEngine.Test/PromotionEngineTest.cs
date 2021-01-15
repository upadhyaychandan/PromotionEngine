using PromotionEngine.Lib;
using PromotionEngine.Lib.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PromotionEngine.Test
{
    public static class PromotionEngineTest
    {
        public static List<Product> Products
        {
            get
            {
                return new List<Product>() {
                    new Product() { Price = 50, SKU = 'A', Promotion = new Promotion(){ PromotionType = "NItemFixed", NoItemsCombined = 3 }, FixedPrice = 130 },
                    new Product() { Price = 30, SKU = 'B', Promotion = new Promotion(){ PromotionType = "NItemFixed", NoItemsCombined = 2 }, FixedPrice = 45 },
                    new Product() { Price = 20, SKU = 'C', Promotion = new Promotion(){ PromotionType = "CombineFixed", NoItemsCombined = 1 }, FixedPrice = 30 },
                    new Product() { Price = 15, SKU = 'D', Promotion = new Promotion(){ PromotionType = "CombineFixed", NoItemsCombined =1 }, FixedPrice = 30 }
                 };
            }
        }
        public static List<Promotion> Promotions
        {
            get
            {
                return new List<Promotion>() {
                    new Promotion() { Name = "3 of A's for 130" , PromotionType = "NItemFixed"},
                    new Promotion() { Name = "2 of B's for 45" ,  PromotionType = "NItemFixed"},
                    new Promotion() { Name = "C & D for 30" ,  PromotionType = "CombineFixed"}
                };
            }
        }

        public static IEnumerable<object[]> GetData(int numTests)
        {
            var allData = new List<object[]>
        {
            new object[] { new CartItem[] { new CartItem() { Product = Products[0], Qty = 1 }, new CartItem() { Product = Products[1], Qty = 1 }, new CartItem() { Product = Products[2], Qty = 1 } }, 100.00 },
            new object[] { new CartItem[] { new CartItem() { Product = Products[0], Qty = 5 }, new CartItem() { Product = Products[1], Qty = 5 }, new CartItem() { Product = Products[2], Qty = 1 } }, 370.00 },
            new object[] { new CartItem[] { new CartItem() { Product = Products[0], Qty = 3 }, new CartItem() { Product = Products[1], Qty = 5 }, new CartItem() { Product = Products[2], Qty = 1 }, new CartItem() { Product = Products[3], Qty = 1 } }, 280.00 }
        };

            return allData.Take(numTests);
        }

        [Theory]
        [MemberData(nameof(GetData), parameters: 3)]
        public static void Test_GetTotalPrice(CartItem[] cartItems, decimal expectedTotal)
        {
            IPromotionEngine promotionEngineSample = new PromotionEngineClient(Products, Promotions, cartItems.ToList());
            decimal totalPriceActual = promotionEngineSample.GetTotalPrice();
            Assert.Equal(expectedTotal, totalPriceActual);
        }
    }
}
