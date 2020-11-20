using StoreLibrary.Intf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PromotionEngine
{
    public class SingleSKUPromotion : IPromotion
    {
        public PromotionResult ApplyPromotion(IEnumerable<IOrderItem> orderItems)
        {
            return PromotionResult.Failure();
        }
    }
}