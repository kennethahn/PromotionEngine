using Microsoft.VisualStudio.TestTools.UnitTesting;
using StoreLibrary.Intf;
using System.Linq;

namespace PromotionEngine.Test
{
    [TestClass]
    public class OrderTotalCalculatorTest
    {
        [TestMethod]
        public void Test_CalculateTotal_WHEN_NoOrderItems_THEN_ItIs0()
        {
            var target = new OrderTotalCalculator();
            var items = Enumerable.Empty<IOrderItem>();
            var total = target.CalculateTotal(items);
            Assert.AreEqual(0, total);
        }
    }
}
