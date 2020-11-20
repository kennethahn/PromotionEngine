using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Test.Stubs;
using StoreLibrary.Intf;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Test
{
    public class CombinedSKUFixedPricePromotionTestBuilder
    {
        private double _fixedPrice;
        private List<string> _skuIdCombo = new List<string>();

        public CombinedSKUFixedPricePromotionTestBuilder WithSKUIdCombo(params string[] skuIds)
        {
            _skuIdCombo.AddRange(skuIds);
            return this;
        }

        public CombinedSKUFixedPricePromotionTestBuilder WithFixedPrice(double fixedPrice)
        {
            _fixedPrice = fixedPrice;
            return this;
        }

        public CombinedSKUFixedPricePromotion Build()
        {
            return new CombinedSKUFixedPricePromotion(_skuIdCombo, _fixedPrice);
        }
    }
}