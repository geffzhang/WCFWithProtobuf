//https://simplespeedtester.codeplex.com/
using ProtoBuf.ServiceModel;
using SimpleSpeedTester.Core;
using SimpleSpeedTester.Core.OutcomeFilters;
using SimpleSpeedTester.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using WcfServiceContract;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var testGroup = new TestGroup("WCfProtobuf");
            // exclude the min and max results 
            ITestOutcomeFilter OutcomeFilter = new ExcludeMinAndMaxTestOutcomeFilter();

            var wcfTestAuthenticateUserSummary =
                testGroup
                    .Plan("AuthenticateUser", () => TestAuthenticateUser(), 10)
                    .GetResult()
                    .GetSummary(OutcomeFilter);
            Console.WriteLine(wcfTestAuthenticateUserSummary);

            //var wcfTestGetAllOrdersSummary =
            //        testGroup
            //            .Plan("TestGetAllOrders", () => TestGetAllOrders(), 10)
            //            .GetResult()
            //            .GetSummary(OutcomeFilter);
            //Console.WriteLine(wcfTestGetAllOrdersSummary);   
            Console.Read();

        }

        private static void TestAuthenticateUser()
        {
            string address = "net.tcp://localhost:50001/SecurityService";
            var binding = new NetTcpBinding() { MaxBufferPoolSize = 524288, MaxReceivedMessageSize = 6553600, MaxBufferSize = 6553600 };
            ChannelFactory<ISimpleContract> factory = new ChannelFactory<ISimpleContract>(binding);
            var endPoint = new EndpointAddress(address);
            factory.Endpoint.Behaviors.Add(new ProtoEndpointBehavior());

            ISimpleContract proxy = factory.CreateChannel(endPoint);

            AuthenticateUserRequest request = new AuthenticateUserRequest()
            {
                UserID = 1,
                Password = "geffzhang@tencent"
            };
            var reponse = proxy.AuthenticateUser(request);
            factory.Close();
        }

        private static void TestGetAllOrders()
        {
            string address = "net.tcp://localhost:50001/OrderService";
            var binding = new NetTcpBinding() { MaxBufferPoolSize = 524288, MaxReceivedMessageSize = 6553600, MaxBufferSize = 6553600 };
            ChannelFactory<IOrderService> factory = new ChannelFactory<IOrderService>(binding);
            var endPoint = new EndpointAddress(address);
            factory.Endpoint.Behaviors.Add(new ProtoEndpointBehavior());

            IOrderService proxy = factory.CreateChannel(endPoint);

            var reponse = proxy.GetAllOrders(1000);
            factory.Close();
        }
    }
}
