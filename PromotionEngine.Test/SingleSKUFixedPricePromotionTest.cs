using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Test.Stubs;
using StoreLibrary.Intf;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Test
{
    [TestClass]
    public class SingleSKUFixedPricePromotionTest
    {
        [TestMethod]
        public void Test_ApplyPromotion_WHEN_NoItems_THEN_ItIsFailure()
        {
            var orderItems = Enumerable.Empty<IOrderItem>();
            SingleSKUFixedPricePromotion target = GetSingleSKUPromotion();

            var result = target.ApplyPromotion(orderItems);
            Assert.IsFalse(result.PromotionWasApplied);
        }



        [TestMethod]
        public void Test_ApplyPromotion_WHEN_ItemsButNoMatching_THEN_ItIsFailure()
        {
            var orderItems = new IOrderItem[]
            { 
                GetSKUOrderItem(PromotionEngineTestContext.Products.A, 1),
                GetSKUOrderItem(PromotionEngineTestContext.Products.C, 2)
            };
            
            var target = GetSingleSKUPromotion(PromotionEngineTestContext.Products.A.ID, 2, 80);

            var result = target.ApplyPromotion(orderItems);
            Assert.IsFalse(result.PromotionWasApplied);
        }

        [TestMethod]
        public void Test_ApplyPromotion_WHEN_ItemMatches_THEN_ItReturnsAdjustmentOf20()
        {
            var orderItems = new IOrderItem[]
            {
                GetSKUOrderItem(PromotionEngineTestContext.Products.A, 2),
                GetSKUOrderItem(PromotionEngineTestContext.Products.C, 2)
            };

            var target = GetSingleSKUPromotion(PromotionEngineTestContext.Products.A.ID, 2, 80);

            var result = target.ApplyPromotion(orderItems);
            Assert.IsTrue(result.PromotionWasApplied);
            Assert.IsNotNull(result.AdjustmentOrderItem);
            Assert.AreEqual(-20, result.AdjustmentOrderItem.Amount);
            Assert.AreEqual(1, result.AppliedToSKUs.Count);
            Assert.AreEqual(PromotionEngineTestContext.Products.A, result.AppliedToSKUs.Single());
        }


        [TestMethod]
        public void Test_ApplyPromotion_WHEN_ItemMatchesAndTriggers2Promotions_THEN_ItReturnsAdjustmentOf40()
        {
            var orderItems = new IOrderItem[]
            {
                GetSKUOrderItem(PromotionEngineTestContext.Products.A, 5),
                GetSKUOrderItem(PromotionEngineTestContext.Products.C, 2)
            };

            var target = GetSingleSKUPromotion(PromotionEngineTestContext.Products.A.ID, 2, 80);

            var result = target.ApplyPromotion(orderItems);
            Assert.IsTrue(result.PromotionWasApplied);
            Assert.AreEqual(-40, result.AdjustmentOrderItem.Amount);
            Assert.AreEqual(PromotionEngineTestContext.Products.A, result.AppliedToSKUs.Single());
        }


        #region helpers

        private static ISKUOrderItem GetSKUOrderItem(ISKU sku, int count)
        {
            return new ISKUOrderItemStubBuilder().WithSKU(sku).WithCount(count).Build();
        }

        
        private static SingleSKUFixedPricePromotion GetSingleSKUPromotion(string skuId = "A", int count = 3, double fixedPrice = 130)
        {
            return new SingleSKUFixedPricePromotionTestBuilder()
                            .WithCount(count)
                            .WithSKUId(skuId)
                            .WithFixedPrice(fixedPrice)
                            .Build();
        }
        #endregion
    }
}