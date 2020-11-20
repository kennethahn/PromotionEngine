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
            var total = target.CalculateTotal(items, PromotionEngineTestContext.ActivePromotions);
            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void Test_CalculateTotal_WHEN_NoPromotionsApply_THEN_TotalIsUnaffected()
        {
            // scenario A
            var orderItems = new IOrderItem[]
            {
                GetSKUOrderItem(PromotionEngineTestContext.Products.A, 1),
                GetSKUOrderItem(PromotionEngineTestContext.Products.B, 1),
                GetSKUOrderItem(PromotionEngineTestContext.Products.C, 1)
            };

            var target = new OrderTotalCalculatorTestBuilder().Build();
            var result = target.CalculateTotal(orderItems, PromotionEngineTestContext.ActivePromotions);
            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void Test_CalculateTotal_WHEN_SingleSKUPromotionsApplyTo1Item_THEN_TotalIsAdjusted()
        {
            var orderItems = new IOrderItem[]
            {
                GetSKUOrderItem(PromotionEngineTestContext.Products.A, 5)
            };

            var target = new OrderTotalCalculatorTestBuilder().Build();
            var result = target.CalculateTotal(orderItems, PromotionEngineTestContext.ActivePromotions);
            Assert.AreEqual(230, result);
        }


        [TestMethod]
        public void Test_CalculateTotal_WHEN_SingleSKUPromotionsApplyTo2Items_THEN_TotalIsAdjusted()
        {
            // scenario B
            var orderItems = new IOrderItem[]
            {
                GetSKUOrderItem(PromotionEngineTestContext.Products.A, 5),
                GetSKUOrderItem(PromotionEngineTestContext.Products.B, 5),
                GetSKUOrderItem(PromotionEngineTestContext.Products.C, 1)
            };

            var target = new OrderTotalCalculatorTestBuilder().Build();
            var result = target.CalculateTotal(orderItems, PromotionEngineTestContext.ActivePromotions);
            Assert.AreEqual(370, result);
        }

        [TestMethod]
        public void Test_CalculateTotal_WHEN_SKUComboPromotionsApply_THEN_TotalIsAdjusted()
        {
            var orderItems = new IOrderItem[]
            {
                GetSKUOrderItem(PromotionEngineTestContext.Products.C, 1),
                GetSKUOrderItem(PromotionEngineTestContext.Products.D, 1)
            };

            var target = new OrderTotalCalculatorTestBuilder().Build();
            var result = target.CalculateTotal(orderItems, PromotionEngineTestContext.ActivePromotions);
            Assert.AreEqual(30, result);
        }


        #region helpers
        private ISKUOrderItem GetSKUOrderItem(ISKU sku, int count)
        {
            return new ISKUOrderItemStubBuilder()
                .WithSKU(sku)
                .WithCount(count)
                .Build();
        }
        #endregion

    }
}

