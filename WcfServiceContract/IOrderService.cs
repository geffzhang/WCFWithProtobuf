using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfServiceContract
{
    [ServiceContract, ProtoBuf.ProtoContract]
    public interface IOrderService
    {
        [OperationContract]
        List<Order> GetAllOrders(int count);
    }
}
