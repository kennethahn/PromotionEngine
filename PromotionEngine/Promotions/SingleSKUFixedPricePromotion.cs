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
            return PromotionResult.Failure();
        }
    }
}