using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrderManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            List<OrderDetail> orderDetails1 = new List<OrderDetail>();
            orderDetails1.Add(new OrderDetail(new Good("book", 12), 3));
            orderDetails1.Add(new OrderDetail(new Good("Costa", 17), 5));
            orderDetails1.Add(new OrderDetail(new Good("Costa", 17), 2));
            Order order1 = new Order(orderNumber: 1, address: "WHU", time: new DateTime(2021, 3, 21, 12, 12, 6), "XBC", "DL", orderDetails1);

            List<OrderDetail> orderDetails2 = new List<OrderDetail>();
            orderDetails2.Add(new OrderDetail(new Good("mat", 12.5), 3));
            orderDetails2.Add(new OrderDetail(new Good("toothbrush", 5), 2));
            orderDetails2.Add(new OrderDetail(new Good("matchstick", 0.1), 50));
            Order order2 = new Order(orderNumber: 5, address: "WHU", time: new DateTime(2020, 3, 22, 13, 11, 7), "LBW", "NB", orderDetails2);

            List<OrderDetail> orderDetails3 = new List<OrderDetail>();
            orderDetails3.Add(new OrderDetail(new Good("computer", 11999), 1));
            orderDetails3.Add(new OrderDetail(new Good("mouse", 88), 1));
            orderDetails3.Add(new OrderDetail(new Good("mat", 15.3), 2));
            Order order3 = new Order(orderNumber: 3, address: "THU", time: new DateTime(2021, 3, 21, 11, 12, 6), "XBC", "DL", orderDetails3);

            List<OrderDetail> orderDetails4 = new List<OrderDetail>();
            orderDetails4.Add(new OrderDetail(new Good("facial cleanser", 33), 2));
            orderDetails4.Add(new OrderDetail(new Good("shower", 37), 1));
            orderDetails4.Add(new OrderDetail(new Good("mat", 16.2), 8));
            Order order4 = new Order(orderNumber: 2, address: "SJTU", time: new DateTime(2019, 3, 21, 3, 51, 6), "YSW", "NB", orderDetails4);

            List<OrderDetail> orderDetails5 = new List<OrderDetail>();
            orderDetails5.Add(new OrderDetail(new Good("knife", 50), 2));
            orderDetails5.Add(new OrderDetail(new Good("sword", 77), 1));
            orderDetails5.Add(new OrderDetail(new Good("shield", 199), 1));
            Order order5 = new Order(orderNumber: 4, address: "FDU", time: new DateTime(2019, 11, 13, 2, 31, 6), "RSC", "DL", orderDetails5);



            OrderService service = new OrderService();
            // 添加
            service.Add(order1);
            service.Add(order2);
            service.Add(order3);
            service.Add(order4);
            service.Add(order5);
            //service.Display();

            service.Export("OrderList.xml");

            //List<Order> orderList = service.Import("orderList.xml");

            foreach (Order order in service.orderList)
                Console.WriteLine(order);
            File.Delete("OrderList.xml");
        }
    }
}
