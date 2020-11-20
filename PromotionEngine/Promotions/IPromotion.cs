using StoreLibrary.Intf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PromotionEngine
{
    public interface IPromotion
    {
        PromotionResult ApplyPromotion(IEnumerable<IOrderItem> orderItems);
    }
}