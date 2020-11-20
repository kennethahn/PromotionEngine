using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Test.Stubs;
using StoreLibrary.Intf;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PromotionEngine.Test
{
    [TestClass]
    public class OrderTotalCalculatorTest
    {
        [TestMethod]
        public void Test_CalculateTotal_WHEN_NoOrderItems_THEN_ItIs0()
        {
            var target = new OrderTotalCalculator();
            var items = Enumerable.Empty<IOrderItem>();
            var total = target.CalculateTotal(items, TestContext.ActivePromotions);
            Assert.AreEqual(0, total);
        }


        [TestMethod]
        public void Test_CalculateTotal_WHEN_NoPromotionsApply_THEN_TotalIsUnaffected()
        {
            // scenario A
            var orderItems = new IOrderItem[]
            {
                GetSKUOrderItem(TestContext.Products.A, 1),
                GetSKUOrderItem(TestContext.Products.B, 1),
                GetSKUOrderItem(TestContext.Products.C, 1)
            };

            var target = new OrderTotalCalculatorTestBuilder().Build();
            var result = target.CalculateTotal(orderItems, TestContext.ActivePromotions);
            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void Test_CalculateTotal_WHEN_SingleSKUPromotionsApplyTo2Items_THEN_TotalIsAdjusted()
        {
            var orderItems = new IOrderItem[]
            {
                GetSKUOrderItem(TestContext.Products.A, 5),
                GetSKUOrderItem(TestContext.Products.B, 5),
                GetSKUOrderItem(TestContext.Products.C, 1)
            };

            var target = new OrderTotalCalculatorTestBuilder().Build();
            var result = target.CalculateTotal(orderItems, TestContext.ActivePromotions);
            Assert.AreEqual(370, result);
        }


        #region helpers
        private ISKUOrderItem GetSKUOrderItem(ISKU sku, int count)
        {
            return new ISKUOrderItemStubBuilder()
                .WithSKU(sku)
                .WithCount(count)
                .WithAmount(count * sku.UnitPrice)
                .Build();
        }
        #endregion

        public class TestContext
        {
            public class Products
            {
                public static ISKU A { get; } = new ISKUStubBuilder().WithId("A").WithUnitPrice(50).Build();
                public static ISKU B { get; } = new ISKUStubBuilder().WithId("B").WithUnitPrice(30).Build();
                public static ISKU C { get; } = new ISKUStubBuilder().WithId("C").WithUnitPrice(20).Build();
                public static ISKU D { get; } = new ISKUStubBuilder().WithId("D").WithUnitPrice(15).Build();

                public static IReadOnlyList<ISKU> All { get; } = new List<ISKU>() { A, B, C, D };

            }

            public static IReadOnlyList<IPromotion> ActivePromotions { get; } = new List<IPromotion>
            {

            };
        }
    }
}
