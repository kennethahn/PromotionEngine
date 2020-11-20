using StoreLibrary.Intf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class OrderTotalCalculator
    {
        public double CalculateTotal(IEnumerable<IOrderItem> orderItems)
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
