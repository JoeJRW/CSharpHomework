using System;
using System.Collections.Generic;

/*
 写一个订单管理的控制台程序，
 能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
 提示：主要的类有Order（订单）、OrderItem（订单明细项），OrderService（订单服务），
 订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
 要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5）OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
 */

namespace Homework5
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
            //----------test search-------
            var query1 = service.SearchById(1);
            foreach (var temp in query1)
                Console.WriteLine(temp);
            var query2 = service.SearchByName("Joe");
            foreach (var temp in query2)
                Console.WriteLine(temp);
            //----------test sort-------
            service.Orders.Sort();
            service.Orders.ForEach(x => Console.WriteLine(x));
        }
    }
}
