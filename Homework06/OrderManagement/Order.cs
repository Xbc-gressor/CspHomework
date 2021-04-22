﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderManagement
{
    [Serializable]
    public class Order : IComparable
    {
        public List<OrderDetail> orderDetails = new List<OrderDetail>();
        public int orderNumber { get; set; } = 0;
        public string address { get; set; } = "somewhere";
        public DateTime time { get; set; }
        public string client { get; set; } = "someone";
        public string seller { get; set; } = "another one";
        public double totolPrice => this.orderDetails.Sum(s => s.good.price * s.num);
        public static T DeepCopyByXml<T>(T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                retval = xml.Deserialize(ms);
                ms.Close();
            }
            return (T)retval;
        }

        public Order()
        {

        }
        public Order(int orderNumber)
        {
            this.orderNumber = orderNumber;
            this.time = DateTime.Now;
 
        }
        public Order(int orderNumber, List<OrderDetail> orderDetails)
        {
            this.orderNumber = orderNumber;
            this.time = DateTime.Now;
            this.orderDetails = orderDetails;
        }
        public Order(int orderNumber, string address, DateTime time, string client, string seller, List<OrderDetail> orderDetails)
        {

            this.orderNumber = orderNumber;
            this.address = address;
            this.time = time;
            this.client = client;
            this.seller = seller;

            int index = 1;
            // 每个订单明细不得一样
            foreach(OrderDetail od in orderDetails)
            {
                if (!this.orderDetails.Contains(od))
                {
                    this.orderDetails.Add(od);
                    od.index = index;
                    index += 1;
                }

            }
            
        }

        // 订单编号唯一确定订单
        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   this.orderNumber == order.orderNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(orderNumber);
        }

        public int CompareTo(object obj)
        {
            var other = obj as Order;
            if(other == null)
                throw new NotImplementedException();

            return this.orderNumber - other.orderNumber;
        }

        public override string ToString()
        {
            string ans = $"{orderNumber.ToString().PadLeft(3, '0')}\t{client} in {address} places an order from {seller} at {time.ToString("yyyy-MM-dd HH:mm:ss")}.\nThe details:";
            ans += "\n\t" + "index".PadLeft(5) + "name".PadLeft(20) + "price".PadLeft(20) + "num".PadLeft(20);
            foreach(OrderDetail od in orderDetails)
            {
                ans += "\n\t" + od;
            }

            ans += "\n" + $"Total price: {totolPrice}\n";
            return ans;

        }
    }
}
