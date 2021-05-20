using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class OrderService
    {
        private OrderContext ctx;

        public OrderService(OrderContext context)
        {
            ctx = context;
            if (ctx.Goods.Count() == 0)
            {
                ctx.Goods.Add(new Good("apple", 100.0));
                ctx.Goods.Add(new Good("egg", 200.0));
                ctx.Goods.Add(new Good("mbp", 13200.0));
                ctx.SaveChanges();
            }
            if (ctx.Clients.Count() == 0)
            {
                ctx.Clients.Add(new Client("Xu"));
                ctx.Clients.Add(new Client("li"));
                ctx.Clients.Add(new Client("zhang"));
                ctx.SaveChanges();
            }
            if (ctx.Orders.Count() == 0)
            {
                OrderDetail detail2 = new OrderDetail(1, new Good("apple", 17), 5);
                ////////////////////////  只能加一个，奇了个怪了
                OrderDetail detail1 = new OrderDetail(0, new Good("book", 12), 3);
                OrderDetail detail3 = new OrderDetail(0, new Good("apple", 17), 2);
                List<OrderDetail> orderDetails1 = new List<OrderDetail>();
                //orderDetails1.Add(detail1);
                orderDetails1.Add(detail2);
                Order order1 = new Order("1", address: "WHU", time: new DateTime(2021, 3, 21, 12, 12, 6), new Client("Xu"), new Client("li"), orderDetails1);
                ctx.Orders.Add(order1);
                List<OrderDetail> orderDetails2 = new List<OrderDetail>();
                orderDetails2.Add(detail1);
                orderDetails2.Add(detail3);
                Order order2 = new Order("23", address: "THU", time: new DateTime(2021, 2, 11, 10, 00, 12), new Client("zhang"), new Client("li"), orderDetails2);
                ctx.Orders.Add(order2);
                ctx.SaveChanges();
            }
        }


        public bool Add(Order order)
        {
            if (order == null)
                throw new ArgumentException("未提供有效的订单！");
            if (!ctx.Orders.Contains(order))
            {
                ctx.Orders.Add(order);
                ctx.Entry(order).State = EntityState.Added;
                ctx.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Order> Search()
        {
            return ctx.Orders
                .Include("Client")
                .Include("Seller")
                .Include(o => o.Details)
                .ThenInclude(d => d.GoodItem)
                .OrderBy(ord => ord.OrderId).ToList();

        }

        /////////////////////////////// 各种查询订单的方法
        public Order SearchById(string Id) // 查询不到会返回null
        {
            // 
            return ctx.Orders
                .Include("Client")
                .Include("Seller")
                .Include(o => o.Details)
                .ThenInclude(d => d.GoodItem)
                .SingleOrDefault(o => o.OrderId == Id);

        }
        public List<Order> SearchByAddress(string address)
        {
            var orders = from odr in ctx.Orders
                         where odr.Address == address
                         orderby odr.TotalPrice
                         select odr;
            return orders.ToList();
        }
        // 精确到天的使劲按查询
        public List<Order> SearchByDate(DateTime date)
        {
            var orders = from odr in ctx.Orders
                         where odr.CreateTime.ToString("yyyy-MM-dd") == date.ToString("yyyy-MM-dd")
                         orderby odr.TotalPrice
                         select odr;
            return orders.ToList();
        }
        public List<Order> SearchByClient(string client)
        {
            var orders = from odr in ctx.Orders
                         where odr.ClientName == client
                         orderby odr.TotalPrice
                         select odr;
            return orders.ToList();
        }
        public List<Order> SearchBySeller(string seller)
        {
            var orders = from odr in ctx.Orders
                         where odr.SellerName == seller
                         orderby odr.TotalPrice
                         select odr;
            return orders.ToList();
        }
        public List<Order> SearchByGood(string goodName)
        {
            return ctx.Orders
                .Include(o => o.Details)
                .ThenInclude(d => d.GoodItem)
                .Include("Client")
                .Include("Seller")
                .Where(order => order.Details.Any(item => item.GoodItem.Name == goodName))
                .ToList();
        }
        /////////////////////// 删除,返回删除的订单信息
        public Order Delete(string Id)
        {
            //Order searchResult = this.SearchByNumber(Id);
            //if (searchResult == null)
            //    throw new ArgumentException("要删除的订单不存在！");

            //Console.WriteLine($"成功删除{Id.ToString().PadLeft(3, '0')}号订单");
            var order = ctx.Orders.Include("Details").SingleOrDefault(o => o.OrderId == Id);
            if (order == null)
                return null;
            ctx.OrderDetails.RemoveRange(order.Details);
            ctx.Orders.Remove(order);
            ctx.SaveChanges();

            return order;
        }

        /////////////////////// 修改
        public void Modify(string Id, Order newOrder)
        {
            //Order searchResult = this.SearchByNumber(orderNumber);
            Delete(Id);
            Add(newOrder);

        }

        //// 序列化
        //public void Export(string filePath)
        //{
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
        //    //if (File.Exists(filePath))
        //    //    throw new ArgumentException("文件已存在!");

        //    using (FileStream fs = new FileStream(filePath, FileMode.Create))
        //    {
        //        xmlSerializer.Serialize(fs, orderList);
        //    }

        //    //Console.WriteLine(File.ReadAllText("OrderList.xml"));
        //}


        //public void Import(string filePath)
        //{
        //    if (!File.Exists(filePath))
        //        throw new FileNotFoundException("文件不存在!");
        //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));

        //    FileStream fs = null;
        //    try
        //    {
        //        fs = new FileStream(filePath, FileMode.Open);
        //        this.orderList = (List<Order>)xmlSerializer.Deserialize(fs);
        //    }
        //    catch (Exception)
        //    {
        //        throw new XmlException("文件格式错误");
        //    }
        //    finally
        //    {
        //        if (fs != null)
        //            fs.Close();
        //    }

        //}

    }
}
