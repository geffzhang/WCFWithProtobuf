using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfServiceContract
{
    /// <summary>
    /// User data contract
    /// </summary>
    [DataContract]
    [ProtoContract]
    public class User
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public Int32 UserID;
        [DataMember(Order = 1)]
        [ProtoMember(2)]
        public String UserName;

        [DataMember(Order = 2)]
        [ProtoMember(3)]
        public String UserEmail;

        [DataMember(Order = 3)]
        [ProtoMember(4)]
        public String Password;

        [DataMember(Order = 4)]
        [ProtoMember(5)]
        public String FirstName;

        [DataMember(Order = 5)]
        [ProtoMember(6)]
        public String LastName;
    }

}
