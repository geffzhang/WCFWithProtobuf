using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfServiceContract
{
    /// <summary>
    /// AuthenticateUserRequest data contract
    /// </summary>
    [DataContract]
    [ProtoContract]
    public class AuthenticateUserRequest
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public Int32 UserID;
        [DataMember(Order = 1)]
        [ProtoMember(2)]
        public String Password;
    }

}
