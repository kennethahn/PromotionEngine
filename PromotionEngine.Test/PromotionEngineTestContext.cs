using PromotionEngine.Test.Stubs;
using StoreLibrary.Intf;
using System.Collections.Generic;

namespace PromotionEngine.Test
{
    public class PromotionEngineTestContext
    {
        public class Products
        {
            public static ISKU A { get; } = new ISKUStubBuilder().WithId("A").WithUnitPrice(50).Build();
            public static ISKU B { get; } = new ISKUStubBuilder().WithId("B").WithUnitPrice(30).Build();
            public static ISKU C { get; } = new ISKUStubBuilder().WithId("C").WithUnitPrice(20).Build();
            public static ISKU D { get; } = new ISKUStubBuilder().WithId("D").WithUnitPrice(15).Build();

            public static IReadOnlyList<ISKU> All { get; } = new List<ISKU>() { A, B, C, D };

        }

        public static IReadOnlyList<IPromotion> ActivePromotions { get; } = new List<IPromotion>
        {
            new SingleSKUFixedPricePromotionTestBuilder().WithSKUId(Products.A.ID).WithCount(3).WithFixedPrice(130).Build(),
            new SingleSKUFixedPricePromotionTestBuilder().WithSKUId(Products.B.ID).WithCount(2).WithFixedPrice(45).Build()
        };
    }
}