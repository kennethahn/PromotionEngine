using System.Collections.Generic;

namespace StoreLibrary.Intf
{
    public interface IPromotionAdjustmentOrderItem : IOrderItem
    {
        IReadOnlyList<IOrderItem> AdjustedOrderItems { get; }
    }
}