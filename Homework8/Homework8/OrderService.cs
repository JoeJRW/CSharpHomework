using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Homework5
{
    public class OrderService
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

        public Order GetOrder(int id)
        {
            return Orders.Where(o => o.OrderId == id).FirstOrDefault();
        }

        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, Orders);
            }
        }

        public void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order => {
                    if (!Orders.Contains(order))
                    {
                        Orders.Add(order);
                    }
                });
            }
        }
    }
}
