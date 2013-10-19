using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WcfServiceContract
{
    /// <summary>
    /// AuthenticateUserResponse data contract
    /// </summary>
    [DataContract]
    [ProtoContract]
    public class AuthenticateUserResponse
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public Int32 StatusCode;
        [DataMember(Order = 1)]
        [ProtoMember(2)]
        public String StatusMessage;
        [DataMember(Order = 2)]
        [ProtoMember(3)]
        public Boolean IsAuthenticated;
    }

}
