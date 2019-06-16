using CoreWcfClient.WcfProxy;
using System;
using System.Collections.Generic;
using System.Text;
using WcfServiceContract;

namespace CoreWcfClient
{
    public class SimpleContractWrapper : ISimpleContract
    {
        private readonly IWcfProxy<ISimpleContract> clientProxy;

        public SimpleContractWrapper(string endpointUrl)
        {
            clientProxy = new WcfProxy<ISimpleContractChannel>(endpointUrl);
        }

        public AuthenticateUserResponse AuthenticateUser(AuthenticateUserRequest userRequestObj)
        {
            var result = clientProxy.Execute(client => client.AuthenticateUser(userRequestObj));
            return result;
        }

        public bool IsAuthenticatedUser(User userObj)
        {
            var result = clientProxy.Execute(client => client.IsAuthenticatedUser(userObj));
            return result;
        }
    }


    public interface ISimpleContractChannel : ISimpleContract, System.ServiceModel.IClientChannel
    {

    }
}
