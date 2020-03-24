using System;
using System.Collections.Generic;

/*
 * 1、在OrderService中添加一个Export方法，可以将所有的订单序列化为XML文件；
 * 添加一个Import方法可以从XML文件中载入订单。
 * 2、对订单程序中OrderService的各个Public方法添加测试用例。
 */

namespace Homework6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<OrderItem> orderItem1 = new List<OrderItem>
            {
                new OrderItem(1, "可乐", 2, 2.5),
                new OrderItem(2, "雪碧", 1, 2.5),
                new OrderItem(3, "乐事", 10, 3),
            };

            List<OrderItem> orderItem2 = new List<OrderItem>
            {
                new OrderItem(1, "乐事", 1, 3)
            };

            List<OrderItem> orderItem3 = new List<OrderItem>
            {
                new OrderItem(1,"可乐",10,2.5)
            };

            Order order1 = new Order(1, "Joe", orderItem1);
            Order order2 = new Order(2, "Jerry", orderItem2);
            Order order3 = new Order(3, "Joe", orderItem3);

            OrderService service = new OrderService();

            //----------test add----------
            service.AddOrder(order1);
            service.AddOrder(order2);
            service.AddOrder(order3);
            service.Orders.ForEach(x => Console.WriteLine(x));

            service.Export("s.xml", service.Orders);

            service.Import("s.xml");
            service.Orders.ForEach(x => Console.WriteLine(x));
        }
    }
}
