using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    class OrderService
    {
        private List<Order> orderList = new List<Order>();
        public enum SortMethod
        {
            Ascending,
            Descending
        }

        public void Display()
        {
            foreach (Order order in orderList)
                Console.WriteLine(order);
        }
        public void Add(Order order)
        {
            if (order == null)
                throw new ArgumentException("未提供有效的订单！");
            if(! orderList.Contains(order) )
            {
                orderList.Add(order);
            }
            else
            {
                throw new ArgumentException("订单已存在！");
            }
        }

        public void Sort(SortMethod met)
        {
            switch(met)
            {
                case SortMethod.Ascending: orderList.Sort(); break;
                case SortMethod.Descending: orderList.Sort(((x, y) => -x.CompareTo(y))); break;

            }
            
        }
        public void Sort(Func<Order, Order, int> lambda)
        {
            orderList.Sort((order1, order2)=>lambda(order1, order2));
        }

        /////////////////////////////// 各种查询订单的方法
        public Order SearchByNumber(int number) // 查询不到会返回null
        {
            var orders = from odr in orderList
                        where odr.orderNumber == number
                        select odr;
            return orders.FirstOrDefault();
        }
        public List<Order> SearchByAddress(string address)
        {
            var orders = from odr in orderList
                         where odr.address == address
                         orderby odr.totolPrice
                         select odr;
            return orders.ToList();
        }
        // 精确到天的使劲按查询
        public List<Order> SearchByDate(DateTime date)
        {
            var orders = from odr in orderList
                         where odr.time.ToString("yyyy-MM-dd") == date.ToString("yyyy-MM-dd")
                         orderby odr.totolPrice
                         select odr;
            return orders.ToList();
        }
        public List<Order> SearchByClient(string client)
        {
            var orders = from odr in orderList
                         where odr.client == client
                         orderby odr.totolPrice
                         select odr;
            return orders.ToList();
        }
        public List<Order> SearchBySeller(string seller)
        {
            var orders = from odr in orderList
                         where odr.seller == seller
                         orderby odr.totolPrice
                         select odr;
            return orders.ToList();
        }
        public List<Order> SearchByGood(string goodName)
        {
            List<Order> ansList = new List<Order>();
            foreach(Order order in orderList)
            {
                bool flag = false;
                foreach(OrderDetail od in order.orderDetails)
                {
                    if (od.good.goodName == goodName)
                    {
                        flag = true;
                        break;
                    }

                }
                if (flag)
                    ansList.Add(order);
            }
            return ansList;
        }
        /////////////////////// 删除,返回删除的订单信息
        public Order Delete(int orderNumber)
        {
            Order searchResult = this.SearchByNumber(orderNumber);
            if (searchResult == null)
                throw new ArgumentException("要删除的订单不存在！");

            Console.WriteLine($"成功删除{orderNumber.ToString().PadLeft(3, '0')}号订单");
            orderList.Remove(searchResult);
            return searchResult;
        }

        /////////////////////// 修改
        public Order Modify(int orderNumber, Order newOrder)
        {
            //Order searchResult = this.SearchByNumber(orderNumber);
            int i = 0;
            for (; i < orderList.Count; i++)
            {
                if (orderList[i].orderNumber == orderNumber)
                    break;
            }
            
            if (i == orderList.Count)
                throw new ArgumentException("要修改的订单不存在！");


            if (newOrder == null)
                throw new ArgumentException("未提供有效的订单！");
            if (newOrder.orderNumber != orderNumber)
                throw new ArgumentException("不支持修改订单号！");

            Order oldOrder = orderList[i];
            orderList[i] = newOrder;
            return oldOrder;

        }
    }
}
