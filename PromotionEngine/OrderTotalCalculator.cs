using StoreLibrary.Intf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PromotionEngine
{
    public class OrderTotalCalculator
    {
        public double CalculateTotal(IEnumerable<IOrderItem> orderItems, IEnumerable<IPromotion> activePromotions)
        {
            double total = 0;
            foreach (var item in orderItems)
            {
                total += item.Amount;
            }
            return total;
        }
    }
}
