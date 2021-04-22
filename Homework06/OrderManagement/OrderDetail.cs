using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    [Serializable]
    public class OrderDetail
    {
        public int index = 0; // 序号
        public Good good = new Good(); // 商品
        public String goodName
        {
            get
            {
                return good.goodName;
            }
            set
            {
                good.goodName = value;
            }
        }
        public double price
        {
            get
            {
                return good.price;
            }
            set
            {
                good.price = value;
            }
        }
        public int num { get; set; } = 0;   // 数量
        public double totalPrice => good.price * num;
        public OrderDetail()
        {

        }
        public OrderDetail(int index)
        {
            this.index = index;
        }
        public OrderDetail(Good good, int num, int index = 0)
        {
            this.index = index;
            this.good = good;
            this.num = num;
        }

        // 商品唯一确定订单明细
        public override bool Equals(object obj)
        {
            return obj is OrderDetail details &&
                   this.good.Equals(details.good);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(good);
        }

        public override string ToString()
        {
            return "   " + index.ToString().PadLeft(2, '0') + good + num.ToString().PadLeft(20);
        }



    }
}
