using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfServiceContract
{
    [DataContract]
    [ProtoContract]
    public partial class OrderLine
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public int ItemID;
        [DataMember(Order = 1)]
        [ProtoMember(2)]
        public int Quantity;
    }
}
