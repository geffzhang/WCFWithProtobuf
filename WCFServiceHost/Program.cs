using ProtoBuf.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using WcfServiceContract;

namespace WCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(SecurityService));
            //string address = "net.tcp://localhost:50001/SecurityService";
    //        var binding = new NetTcpBinding() { MaxBufferPoolSize = 524288, MaxReceivedMessageSize = 6553600, MaxBufferSize = 6553600 };
    //        //binding.Security.Mode = SecurityMode.None;
    //        ServiceEndpoint endpoint = host.AddServiceEndpoint(
    //typeof(ISimpleContract), binding, address);
    //        endpoint.Behaviors.Add(new ProtoEndpointBehavior());
            host.Opened += host_Opened;
            host.Open();
            ServiceHost host1 = new ServiceHost(typeof(OrderService));
            host1.Opened += host1_Opened;
            host1.Open();
            Console.Read();
            host.Close();
            host1.Close();
        }

        static void host_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("SecurityService has Started");
        }

        static void host1_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("OrderService has Started");
        }
    }
}
