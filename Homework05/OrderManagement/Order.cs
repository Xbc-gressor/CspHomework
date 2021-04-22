using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    public class Order: IComparable
    {
        public List<OrderDetail> orderDetails = new List<OrderDetail>();
        public int orderNumber { get; set; }
        public string address { get; set; }
        public DateTime time { get; set; }
        public string client { get; set; }
        public string seller { get; set; }
        public double totalPrice { get; set; }



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
            this.totalPrice = this.orderDetails.Sum(s => s.GTotalPrice);
        }

        // 订单编号唯一确定订单
        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   this.orderNumber == order.orderNumber;
        }
        public static bool operator ==(Order left, Order right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Order left, Order right)
        {
            return !Equals(left, right);
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

            ans += "\n" + $"Total price: {totalPrice}\n";
            return ans;

        }
    }
}
