using System;
using System.Collections.Generic;

namespace StoreLibrary.Intf
{
public interface ISKUOrderItem : IOrderItem
    {
        public ISKU SKU { get; }
        public int Count { get; }
    }
}