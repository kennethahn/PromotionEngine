using Moq;
using StoreLibrary.Intf;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Test.Stubs
{
    public abstract class StubBuilder<T> where T : class
    {
        protected Mock<T> MyMock { get; } = new Mock<T>();

        public T Build()
        {
            return MyMock.Object;
        }
    }
}