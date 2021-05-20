using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class Order
    {
        public string OrderId { get; set; }

        public string ClientId { get; set; }
        public Client Client { get; set; }
        public string SellerId { get; set; }
        public Client Seller { get; set; }
        public string ClientName { get => (Client != null) ? Client.Name : ""; }
        public string SellerName { get => (Seller != null) ? Seller.Name : ""; }


        public DateTime CreateTime { get; set; }
        public string Address { get; set; }

        public List<OrderDetail> Details { get; set; }

        public double TotalPrice => this.Details.Sum(s => s.TotalPrice);

        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            Details = new List<OrderDetail>();
            CreateTime = DateTime.Now;
        }

        public Order(string orderId, string address, DateTime time, Client client, Client seller, List<OrderDetail> orderDetails) : this()
        {
            this.OrderId = orderId;
            this.Address = address;
            this.CreateTime = time;
            this.Client = client;
            this.Seller = seller;
            int index = 1;
            // 每个订单明细不得一样
            foreach (OrderDetail od in orderDetails)
            {
                if (!this.Details.Contains(od))
                {
                    this.Details.Add(od);
                    od.Index = index;
                    index += 1;
                }
                else
                {
                    this.Details[0].text = $"{this.Details[0].GoodId} {this.Details[0].GoodName} {od.GoodId} {od.GoodName}";
                }
            }
        }


        public void AddDetail(OrderDetail orderItem)
        {
            if (Details.Contains(orderItem))
                throw new ApplicationException($"添加错误：订单项{orderItem.GoodName} 已经存在!");
            Details.Add(orderItem);
        }

        public void RemoveDetail(OrderDetail orderItem)
        {
            Details.Remove(orderItem);
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append($"Id:{OrderId}, client:{Client},orderTime:{CreateTime},totalPrice：{TotalPrice}");
            Details.ForEach(od => strBuilder.Append("\n\t" + od));
            return strBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null &&
                   OrderId == order.OrderId;
        }

        public override int GetHashCode()
        {
            var hashCode = -531220479;
            hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ClientName);
            hashCode = hashCode * -1521134295 + CreateTime.GetHashCode();
            return hashCode;
        }

        public int CompareTo(Order other)
        {
            if (other == null) return 1;
            return this.OrderId.CompareTo(other.OrderId);
        }
    }

}
