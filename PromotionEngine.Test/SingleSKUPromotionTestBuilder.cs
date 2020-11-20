using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Test.Stubs;
using StoreLibrary.Intf;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Test
{
    public class SingleSKUPromotionTestBuilder
    {
        public SingleSKUPromotion Build()
        {
            return new SingleSKUPromotion();
        }
    }
}