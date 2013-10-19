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
    public partial class Order
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public int CustomerID;
        [DataMember(Order = 1)]
        [ProtoMember(2)]
        public string ShippingAddress1;
        [DataMember(Order = 2)]
        [ProtoMember(3)]
        public string ShippingAddress2;
        [DataMember(Order = 3)]
        [ProtoMember(4)]
        public string ShippingCity;
        [DataMember(Order = 4)]
        [ProtoMember(5)]
        public string ShippingState;
        [DataMember(Order = 5)]
        [ProtoMember(6)]
        public string ShippingZip;
        [DataMember(Order = 6)]
        [ProtoMember(7)]
        public string ShippingCountry;
        [DataMember(Order = 7)]
        [ProtoMember(8)]
        public string ShipType;
        [DataMember(Order = 8)]
        [ProtoMember(9)]
        public string CreditCardType;
        [DataMember(Order = 9)]
        [ProtoMember(10)]
        public string CreditCardNumber;
        [DataMember(Order = 10)]
        [ProtoMember(11)]
        public DateTime CreditCardExpiration;
        [DataMember(Order = 11)]
        [ProtoMember(12)]
        public string CreditCardName;
        [DataMember(Order = 12)]
        [ProtoMember(13)]
        public OrderLine[] OrderItems;
    }

}
