using StoreLibrary.Intf;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class PromotionResult
    {
        public bool PromotionWasApplied { get; }
        public IPromotionAdjustmentOrderItem AdjustmentOrderItem { get; }
        public IReadOnlyList<ISKU> AppliedToSKUs { get; }

        public static PromotionResult Success(IPromotionAdjustmentOrderItem adjustment, IEnumerable<ISKU> appliedToSkus)
        {
            return new PromotionResult(true, adjustment, appliedToSkus);
        }

        public static PromotionResult Failure()
        {
            return new PromotionResult(false, null, Enumerable.Empty<ISKU>());
        }

        private PromotionResult(bool promotionWasApplied, IPromotionAdjustmentOrderItem adjustment, IEnumerable<ISKU> appliedToSkus)
        {
            PromotionWasApplied = promotionWasApplied;
            AdjustmentOrderItem = adjustment;
            AppliedToSKUs = appliedToSkus.ToList();
        }
    }
}