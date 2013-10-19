using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WcfServiceContract;

namespace WCFServiceHost
{
    public class OrderService : IOrderService
    {
        public List<Order> GetAllOrders(int count)
        {
            List<Order> list = new List<Order>();
            for(int i=0; i< count; i++)
            {
                List<OrderLine> orderItems = new List<OrderLine>();
                Order order = new Order() {   CustomerID = i, CreditCardExpiration = DateTime.Now, CreditCardName = string.Format("Credit{0}",i) , CreditCardNumber = i.ToString(), CreditCardType = "Visa",
                 OrderItems =  orderItems.ToArray(), ShippingAddress1 ="", ShippingAddress2="", ShippingCity="shenzhen", ShippingCountry="China", ShippingState="518050", ShippingZip ="", ShipType ="Car" };
                list.Add(order);                
            }
            return list;
        }
    }
}
