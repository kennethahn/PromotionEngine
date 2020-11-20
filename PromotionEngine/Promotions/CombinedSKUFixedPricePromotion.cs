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
        {
            return PromotionResult.Failure();
        }
    }
}