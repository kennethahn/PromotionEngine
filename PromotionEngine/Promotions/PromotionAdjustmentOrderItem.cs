using StoreLibrary.Intf;

namespace PromotionEngine
{
    public class PromotionAdjustmentOrderItem : IOrderItem
    {
        public double Amount { get; }

        public PromotionAdjustmentOrderItem(double amount) => Amount = amount;
    }
}