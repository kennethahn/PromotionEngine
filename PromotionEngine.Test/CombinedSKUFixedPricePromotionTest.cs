using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Test.Stubs;
using StoreLibrary.Intf;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Test
{
    [TestClass]
    public class CombinedSKUFixedPricePromotionTest
    {
        [TestMethod]
        public void Test_ApplyPromotion_WHEN_PromotionDoesntAppply_THEN_ItIsFailure()
        {
            var orderItems = new IOrderItem[]
            {
                GetSKUOrderItem(PromotionEngineTestContext.Products.A, 1),
                GetSKUOrderItem(PromotionEngineTestContext.Products.B, 1),
                GetSKUOrderItem(PromotionEngineTestContext.Products.C, 1)
            };

            var target = new CombinedSKUFixedPricePromotionTestBuilder()
                .WithFixedPrice(15)
                .WithSKUIdCombo(PromotionEngineTestContext.Products.C.ID, PromotionEngineTestContext.Products.D.ID)
                .Build();

            var result = target.ApplyPromotion(orderItems);
            Assert.IsFalse(result.PromotionWasApplied);
        }

        [TestMethod]
        public void Test_ApplyPromotion_WHEN_PromotionApppliesOnce_THEN_ItAdjustTotalWith5()
        {
            var orderItems = new ISKUOrderItem[]
            {
                GetSKUOrderItem(PromotionEngineTestContext.Products.C, 1),
                GetSKUOrderItem(PromotionEngineTestContext.Products.D, 1)
            };

            var target = new CombinedSKUFixedPricePromotionTestBuilder()
                .WithFixedPrice(15)
                .WithSKUIdCombo(PromotionEngineTestContext.Products.C.ID, PromotionEngineTestContext.Products.D.ID)
                .Build();

            var result = target.ApplyPromotion(orderItems);
            Assert.IsTrue(result.PromotionWasApplied);
            Assert.IsNotNull(result.AdjustmentOrderItem);
            Assert.AreEqual(-5, result.AdjustmentOrderItem.Amount);
            Assert.AreEqual(2, result.AppliedToSKUs.Count);
            Assert.IsTrue(result.AppliedToSKUs.Any(x => x == PromotionEngineTestContext.Products.A));
            Assert.IsTrue(result.AppliedToSKUs.Any(x => x == PromotionEngineTestContext.Products.B));
        }

        #region helpers
        private static ISKUOrderItem GetSKUOrderItem(ISKU sku, int count)
        {
            return new ISKUOrderItemStubBuilder().WithSKU(sku).WithCount(count).Build();
        }
        #endregion
    }
}