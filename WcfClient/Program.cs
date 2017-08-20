//https://simplespeedtester.codeplex.com/
using ProtoBuf.ServiceModel;
using SimpleSpeedTester.Core;
using SimpleSpeedTester.Core.OutcomeFilters;
using SimpleSpeedTester.Interfaces;
using System;
using System.ServiceModel;
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

            var wcfTestGetAllOrdersSummary =
                    testGroup
                        .Plan("TestGetAllOrders", () => TestGetAllOrders(), 10)
                        .GetResult()
                        .GetSummary(OutcomeFilter);
            Console.WriteLine(wcfTestGetAllOrdersSummary);   
            Console.Read();

        }

        private static void TestAuthenticateUser()
        {
            //string address = "net.tcp://localhost:50001/SecurityService";
            //var binding = new NetTcpBinding() { MaxBufferPoolSize = 524288, MaxReceivedMessageSize = 6553600, MaxBufferSize = 6553600 };
            //binding.Security.Mode = SecurityMode.None;
            //var endPoint = new EndpointAddress(address);
            //ChannelFactory<ISimpleContract> factory = new ChannelFactory<ISimpleContract>(binding, endPoint);         
            //factory.Endpoint.Behaviors.Add(new ProtoEndpointBehavior());

            ChannelFactory<ISimpleContract> factory = new ChannelFactory<ISimpleContract>("SecurityService");
            ISimpleContract proxy = factory.CreateChannel();
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
            //string address = "net.tcp://localhost:50002/OrderService";
            //var binding = new NetTcpBinding() { MaxBufferPoolSize = 524288, MaxReceivedMessageSize = 6553600, MaxBufferSize = 6553600 };
            //var endPoint = new EndpointAddress(address);
            //ChannelFactory<IOrderService> factory = new ChannelFactory<IOrderService>(binding,endPoint);
            //factory.Endpoint.Behaviors.Add(new ProtoEndpointBehavior());

            ChannelFactory<IOrderService> factory = new ChannelFactory<IOrderService>("OrderService");
            IOrderService proxy = factory.CreateChannel();
            var reponse = proxy.GetAllOrders(1000);
            factory.Close();
        }
    }
}
