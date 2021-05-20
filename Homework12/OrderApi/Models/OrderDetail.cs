using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class OrderDetail
    {
        public string OrderDetailId { get; set; }
        public int Index { get; set; } //序号

        /////
        public string GoodId { get; set; }
        public Good GoodItem { get; set; }
        public String GoodName { get => GoodItem != null ? this.GoodItem.Name : ""; }

        public int Num { get; set; } = 0; // 数量
        public double TotalPrice { get => GoodItem != null ? this.GoodItem.Price * Num : 0.0; }
        public String text { get; set; }

        /////
        public string OrderId { get; set; }

        public OrderDetail()
        {
            OrderDetailId = Guid.NewGuid().ToString();
        }

        public OrderDetail(int index, Good goods, int num): this()
        {
            this.Index = index;
            this.GoodId = goods.GoodId;
            this.GoodItem = goods;
            this.Num = num;
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderDetail;
            return item != null &&
                   GoodId == item.GoodId;
        }

        public override int GetHashCode()
        {
            var hashCode = -2127770830;
            hashCode = hashCode * -1521134295 + Index.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodName);
            hashCode = hashCode * -1521134295 + Num.GetHashCode();
            return hashCode;
        }
        public override string ToString()
        {
            return $"[No.:{Index},goods:{GoodName},Num:{Num},totalPrice:{TotalPrice}]";
        }
    }
}
