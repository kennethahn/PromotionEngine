using StoreLibrary.Intf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PromotionEngine
{
    public class SingleSKUFixedPricePromotion : IPromotion
    {
        private readonly string _skuId;
        private readonly int _count;
        private readonly double _fixedPrice;

        public SingleSKUFixedPricePromotion(string skuId, int count, double fixedPrice)
        {
            _skuId = skuId;
            _count = count;
            _fixedPrice = fixedPrice;
        }
        public PromotionResult ApplyPromotion(IEnumerable<IOrderItem> orderItems)
        {
            var result = PromotionResult.Failure();

            var skuOrderItem = GetFirstApplicableOrderItem(orderItems);

            if (skuOrderItem != null)
            {
                var fixedPriceMultiplier = skuOrderItem.Count / _count;
                var adjustmentAmount = skuOrderItem.Amount - fixedPriceMultiplier * _fixedPrice;
                var adjustmentOrderItem = new PromotionAdjustmentOrderItem(-adjustmentAmount);
                return PromotionResult.Success(adjustmentOrderItem, new ISKU[] { skuOrderItem.SKU });
            }
            return result;
        }

        private ISKUOrderItem GetFirstApplicableOrderItem(IEnumerable<IOrderItem> orderItems)
        {
            return orderItems.OfType<ISKUOrderItem>()
                            .Where(x => x.SKU.ID == _skuId)
                            .Where(x => x.Count >= _count)
                            .FirstOrDefault();
        }
    }
}