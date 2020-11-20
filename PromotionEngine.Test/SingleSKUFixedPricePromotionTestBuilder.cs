using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Test.Stubs;
using StoreLibrary.Intf;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Test
{
    public class SingleSKUFixedPricePromotionTestBuilder
    {
        private double _fixedPrice;
        private int _count;
        private string _skuId;

        public SingleSKUFixedPricePromotionTestBuilder WithSKUId(string skuId)
        {
            _skuId = skuId;
            return this;
        }

        public SingleSKUFixedPricePromotionTestBuilder WithCount(int count)
        {
            _count = count;
            return this;
        }

        public SingleSKUFixedPricePromotionTestBuilder WithFixedPrice(double fixedPrice)
        {
            _fixedPrice = fixedPrice;
            return this;
        }

        public SingleSKUFixedPricePromotion Build()
        {
            return new SingleSKUFixedPricePromotion(_skuId, _count, _fixedPrice);
        }
    }
}