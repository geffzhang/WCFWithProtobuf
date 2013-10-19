using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WCFServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(SecurityService));
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
