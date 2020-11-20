using Moq;
using StoreLibrary.Intf;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PromotionEngine.Test.Stubs
{
public class ISKUOrderItemStubBuilder : StubBuilder<ISKUOrderItem>
{
        public ISKUOrderItemStubBuilder WithSKU(ISKU sku)
        {
            MyMock.SetupGet(x => x.SKU).Returns(sku);
            return this;
        }

        public ISKUOrderItemStubBuilder WithCount(int count)
        {
            MyMock.SetupGet(x => x.Count).Returns(count);
            return this;
        }

        protected override void OnBuild()
        {
            base.OnBuild();
            MyMock.SetupGet(x => x.Amount).Returns(MyMock.Object.Count * MyMock.Object.SKU.UnitPrice);
        }

    }
}