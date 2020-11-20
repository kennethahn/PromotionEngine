using StoreLibrary.Intf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PromotionEngine
{
    public class CombinedSKUFixedPricePromotion : IPromotion
    {
        private readonly double _fixedPrice;
        private readonly List<string> _skuIdCombination;

        public CombinedSKUFixedPricePromotion(IEnumerable<string> skuIdCombination, double fixedPrice)
        {
            _fixedPrice = fixedPrice;
            _skuIdCombination = skuIdCombination.ToList();
        }

        public PromotionResult ApplyPromotion(IEnumerable<IOrderItem> orderItems)
        {  // assumption: max 1 order item per SKU
            var result = PromotionResult.Failure();

            var relevantOrderItems = orderItems.OfType<ISKUOrderItem>()
                .Where(x => _skuIdCombination.Contains(x.SKU.ID))
                .ToList();

            if(relevantOrderItems.Count == _skuIdCombination.Count)
            {
                var combinedUnitPriceBeforeAdjustment = relevantOrderItems.Sum(x => x.SKU.UnitPrice);
                var adjustment = combinedUnitPriceBeforeAdjustment - _fixedPrice;
                var adjustmentItem = new PromotionAdjustmentOrderItem(-adjustment);
                return PromotionResult.Success(adjustmentItem, relevantOrderItems.Select(x => x.SKU));
            }
            return result;
        }
    }
}