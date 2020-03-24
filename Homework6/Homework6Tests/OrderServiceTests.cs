using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace Homework6.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestCleanup]
        public void TestCleanup()
        {
            OrderService service = new OrderService();
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            List<OrderItem> orderItem1 = new List<OrderItem>
            {
                new OrderItem(1, "可乐", 2, 2.5),
                new OrderItem(2, "雪碧", 1, 2.5),
                new OrderItem(3, "乐事", 10, 3),
            };
            Order order1 = new Order(1, "Joe", orderItem1);
            OrderService service = new OrderService();
            service.AddOrder(order1);
            if (service.Orders != null)
            {
                bool equal = true;
                service.Orders.ForEach(x => equal = x.Equals(order1) && equal);
                if (equal)
                    return;
            }           
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            List<OrderItem> orderItem1 = new List<OrderItem>
            {
                new OrderItem(1, "可乐", 2, 2.5),
                new OrderItem(2, "雪碧", 1, 2.5),
                new OrderItem(3, "乐事", 10, 3),
            };
            Order order1 = new Order(1, "Joe", orderItem1);
            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.DeleteOrder(order1);
            Assert.AreEqual<int>(0, service.Orders.Count);
        }

        [TestMethod()]
        public void SearchByIdTest()
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

            Order order1 = new Order(1, "Joe", orderItem1);
            Order order2 = new Order(2, "Jerry", orderItem2);

            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);
            
            var query = service.SearchById(2);
            if (query != null)
            {
                bool equal = true;
                foreach (var temp in query)
                    equal = temp.Equals(order2) && equal;
                if (equal)
                    return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void SearchByNameTest()
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

            Order order1 = new Order(1, "Joe", orderItem1);
            Order order2 = new Order(2, "Jerry", orderItem2);

            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);

            var query = service.SearchByName("Jerry");
            if (query != null)
            {
                bool equal = true;
                foreach (var temp in query)
                    equal = temp.Equals(order2) && equal;
                if (equal)
                    return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void SearchByDetailTest()
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

            Order order1 = new Order(1, "Joe", orderItem1);
            Order order2 = new Order(2, "Jerry", orderItem2);

            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);

            var query = service.SearchByName("可乐");
            if (query != null)
            {
                bool equal = true;
                foreach (var temp in query)
                    equal = temp.Equals(order1) && equal;
                if (equal)
                    return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void ModifyOrderTest()
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

            Order order1 = new Order(1, "Joe", orderItem1);
            Order order2 = new Order(2, "Jerry", orderItem2);

            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);

            List<OrderItem> neworderItem2 = new List<OrderItem>
            {
                new OrderItem(1, "乐事", 2, 3)
            };
            Order neworder2 = new Order(2, "Jerry", neworderItem2);
            service.ModifyOrder(order2, neworder2);
            var query = service.SearchById(2);
            if (query != null)
            {
                bool equal = true;
                foreach (var temp in query)
                    equal = temp.Equals(neworder2) && equal;
                if (equal)
                    return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void ExportTest()
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

            Order order1 = new Order(1, "Joe", orderItem1);
            Order order2 = new Order(2, "Jerry", orderItem2);

            OrderService service = new OrderService();
            service.AddOrder(order1);
            service.AddOrder(order2);

            service.Export("s.xml", service.Orders);
            Assert.IsTrue(File.Exists("s.xml"));
        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService service = new OrderService();
            service.Import("t.xml");
            Assert.AreNotEqual<int>(0, service.Orders.Count);
        }
    }
}