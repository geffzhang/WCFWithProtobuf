using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using WcfServiceContract;

namespace CoreWcfClient
{
    class Program
    {
        static void Main(string[] args)
        {           
            TestAuthenticateUser();
            Console.WriteLine("Hello World!");
            Console.Read();
        }

        private static void TestAuthenticateUser()
        {
            string address = "net.tcp://localhost:50001/SecurityService";
            ISimpleContract provider = new SimpleContractWrapper(address);
            AuthenticateUserRequest request = new AuthenticateUserRequest()
            {
                UserID = 1,
                Password = "geffzhang@tencent"
            };
            var reponse = provider.AuthenticateUser(request);
            Console.WriteLine(reponse.StatusMessage);
        
        }

    }
}
