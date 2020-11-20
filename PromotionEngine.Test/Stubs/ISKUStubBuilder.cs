using Moq;
using StoreLibrary.Intf;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PromotionEngine.Test.Stubs
{
    public class ISKUStubBuilder : StubBuilder<ISKU>
    {
        public ISKUStubBuilder WithId(string id)
        {
            MyMock.SetupGet(x => x.ID).Returns(id);
            return this;
        }

        public ISKUStubBuilder WithUnitPrice(double unitPrice)
        {
            MyMock.SetupGet(x => x.UnitPrice).Returns(unitPrice);
            return this;
        }
    }
}
