using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Homework5
{
    class OrderService
    {
        public List<Order> Orders { get; set; }

        public OrderService()
        {
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            foreach (var temp in Orders)
            {
                if (order.Equals(temp))
                    return;
            }
            Orders.Add(order);
            Console.WriteLine("成功添加" + order.ToString());
        }

        public void DeleteOrder(Order order)
        {
            try
            {
                for (int i = Orders.Count - 1; i >= 0; i--)
                {
                    if (order.Equals(Orders[i]))
                    {
                        Orders.Remove(Orders[i]);
                        Console.WriteLine("成功删除" + order.ToString());
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("删除失败，原因：" + e.Message);
            }
            
        }

        public IEnumerable SearchById(int id)
        {
            var query = from temp in Orders
                        where temp.OrderId == id
                        orderby temp.SumPrice
                        select temp;
            return query;
        }

        public IEnumerable SearchByName(string name)
        {
            var query = from temp in Orders
                        where temp.CusName == name
                        orderby temp.SumPrice
                        select temp;
            return query;
        }

        public void ModifyOrder(Order exorder, Order order)
        {
            try
            {
                foreach (var temp in Orders)
                {
                    if (exorder.Equals(temp))
                    {
                        Orders.Remove(temp);
                        Orders.Add(order);
                        Console.WriteLine($"已将订单{order.OrderId}修改为："+order.ToString());
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("修改失败，原因："+e.Message);
            }
        }
    }
}
