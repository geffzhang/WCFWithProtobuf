using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceContract
{
    [ServiceContract, ProtoBuf.ProtoContract]
    public interface ISimpleContract
    {
        [OperationContract]
        Boolean IsAuthenticatedUser(User userObj);

        /// <summary>
        /// AuthenticateUser operation contract
        /// </summary>
        /// <param name="userRequestObj">userRequestObj as an instance of AuthenticateUserRequest</param>
        /// <returns>An instance of AuthenticateUserResponse</returns>
        [OperationContract]
        AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest userRequestObj);

    }

}
