using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OrderManagement.OrderTests
{
    [TestClass()]
    public class OrderServiceTests
    {
        //[TestMethod()]
        //public void OrderServiceTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DisplayTest()
        //{
        //    Assert.Fail();
        //}
        OrderService orderService = new OrderService();
        Order order1;
        Order order2;
        Order order3;
        Order order4;
        Order order5;

        [TestInitialize]
        public void Init()
        {

            List<OrderDetail> orderDetails1 = new List<OrderDetail>();
            orderDetails1.Add(new OrderDetail(new Good("book", 12), 3));
            orderDetails1.Add(new OrderDetail(new Good("Costa", 17), 5));
            orderDetails1.Add(new OrderDetail(new Good("Costa", 17), 2));
            order1 = new Order(orderNumber: 1, address: "WHU", time: new DateTime(2021, 3, 21, 12, 12, 6), "XBC", "DL", orderDetails1);

            List<OrderDetail> orderDetails2 = new List<OrderDetail>();
            orderDetails2.Add(new OrderDetail(new Good("mat", 12.5), 3));
            orderDetails2.Add(new OrderDetail(new Good("toothbrush", 5), 2));
            orderDetails2.Add(new OrderDetail(new Good("matchstick", 0.1), 50));
            order2 = new Order(orderNumber: 5, address: "WHU", time: new DateTime(2020, 3, 22, 13, 11, 7), "LBW", "NB", orderDetails2);

            List<OrderDetail> orderDetails3 = new List<OrderDetail>();
            orderDetails3.Add(new OrderDetail(new Good("computer", 11999), 1));
            orderDetails3.Add(new OrderDetail(new Good("mouse", 88), 1));
            orderDetails3.Add(new OrderDetail(new Good("mat", 15.3), 2));
            order3 = new Order(orderNumber: 3, address: "THU", time: new DateTime(2021, 3, 21, 11, 12, 6), "XBC", "DL", orderDetails3);

            List<OrderDetail> orderDetails4 = new List<OrderDetail>();
            orderDetails4.Add(new OrderDetail(new Good("facial cleanser", 33), 2));
            orderDetails4.Add(new OrderDetail(new Good("shower", 37), 1));
            orderDetails4.Add(new OrderDetail(new Good("mat", 16.2), 8));
            order4 = new Order(orderNumber: 2, address: "SJTU", time: new DateTime(2019, 3, 21, 3, 51, 6), "YSW", "NB", orderDetails4);

            List<OrderDetail> orderDetails5 = new List<OrderDetail>();
            orderDetails5.Add(new OrderDetail(new Good("knife", 50), 2));
            orderDetails5.Add(new OrderDetail(new Good("sword", 77), 1));
            orderDetails5.Add(new OrderDetail(new Good("shield", 199), 1));
            order5 = new Order(orderNumber: 4, address: "FDU", time: new DateTime(2019, 11, 13, 2, 31, 6), "RSC", "DL", orderDetails5);



            bool res1 = orderService.Add(order1);
            bool res2 = orderService.Add(order2);
            bool res3 = orderService.Add(order3);
            bool res4 = orderService.Add(order4);
            bool res5 = orderService.Add(order5);
        }

        [TestMethod()]
        public void AddTest()
        {

            Assert.AreEqual(5, orderService.orderList.Count);

            Order order6 = new Order(3);
            bool res6 = orderService.Add(order6);

            Assert.AreEqual(false, res6);
        }

        [TestMethod()]
        public void SortTest()
        {
            orderService.Sort();
            int[] IDList = new int[5];
            
            for(int i = 0; i < orderService.orderList.Count; i++)
            {
                IDList[i] = orderService.orderList[i].orderNumber;
            }
            CollectionAssert.AreEqual(new int[]{ 1,2,3,4,5}, IDList);
        }

        [TestMethod()]
        public void SortTest1()
        {
            // 按照序号降序排列
            orderService.Sort((x, y) => -(x.orderNumber-y.orderNumber));
            int[] IDList = new int[5];

            for (int i = 0; i < orderService.orderList.Count; i++)
            {
                IDList[i] = orderService.orderList[i].orderNumber;
            }
            CollectionAssert.AreEqual(new int[] { 5, 4, 3, 2, 1 }, IDList);
        }

        [TestMethod()]
        public void SearchByNumberTest()
        {
            Order order = new Order(3);

            Order searchRes = orderService.SearchByNumber(3);
            Assert.AreEqual(order, searchRes);
        }

        [TestMethod()]
        public void SearchByAddressTest()
        {
            List < Order > searchRes = orderService.SearchByAddress("WHU");
            CollectionAssert.AreEqual(new List<Order>(new Order[] { order2, order1 }), searchRes);
        }

        [TestMethod()]
        public void SearchByDateTest()
        {
            List<Order> searchRes = orderService.SearchByDate(new DateTime(2021, 3, 21));
            CollectionAssert.AreEqual(new List<Order>(new Order[] { order1, order3 }), searchRes);
        }

        [TestMethod()]
        public void SearchByClientTest()
        {
            List<Order> searchRes = orderService.SearchByClient("YSW");
            CollectionAssert.AreEqual(new List<Order>(new Order[] { order4}), searchRes);

        }

        [TestMethod()]
        public void SearchBySellerTest()
        {
            List<Order> searchRes = orderService.SearchBySeller("DL");
            CollectionAssert.AreEqual(new List<Order>(new Order[] { order1, order5, order3 }), searchRes);
        }

        [TestMethod()]
        public void SearchByGoodTest()
        {
            List<Order> searchRes = orderService.SearchByGood("mat");

            CollectionAssert.AreEqual(new List<Order>(new Order[] { order2, order4, order3 }), searchRes);

        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTest()
        {

            orderService.Delete(23);

        }

        [TestMethod()]
        public void DeleteTest1()
        {
            OrderService service = new OrderService();
            service.Add(new Order(1));
            service.Add(new Order(2));
            service.Add(new Order(3));

            service.Delete(2);

            Assert.AreEqual(service.orderList.Count, 2);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ModifyTest()
        {
            OrderService service = new OrderService();
            service.Add(new Order(1));
            service.Add(new Order(2));

            // 提供的订单号和要修改的不一样
            service.Modify(2, order2);
        }
        [TestMethod()]
        public void ModifyTest1()
        {
            OrderService service = new OrderService();
            service.Add(new Order(1));
            service.Add(new Order(2));

            Order ori = service.Modify(2, order4);

            Assert.AreEqual(new Order(2), ori);
            Assert.AreEqual(service.SearchByNumber(2), order4);

        }
        [TestMethod()] // 导出时文件已存在
        [ExpectedException(typeof(ArgumentException))]
        public void ExportTest()
        {
            orderService.Export("orderList.xml");
            
            orderService.Export("orderList.xml");

        }

        [TestMethod()] // 导入时格式错误的文件
        [ExpectedException(typeof(XmlException))]
        public void ImportTest()
        {
            orderService.Import("orderList1.xml");
        }

        [TestMethod()] // 导入时文件不存在
        [ExpectedException(typeof(FileNotFoundException))]
        public void ImportTest1()
        {
            orderService.Import("orde111r.xml");
        }

    }
}