using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderApp
{

    /**
     **/
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int Index { get; set; }
        public int OrderId { get; set; }
        public string GoodsId { get; set; }
        public Goods GoodsItem { get; set; }
        public String GoodsName { get => GoodsItem != null ? this.GoodsItem.Name : ""; }
        public double UnitPrice { get => GoodsItem != null ? this.GoodsItem.Price : 0.0; }
        public int Quantity { get; set; }

        private static int index = 0;
        public OrderDetail() 
        {
            OrderDetailId = index;
            index += 1;
        }

        public OrderDetail(int ind, Goods goods, int quantity): this()
        {
            this.Index = ind;
            this.GoodsItem = goods;
            this.Quantity = quantity;
        }

        public double TotalPrice
        {
            get => GoodsItem == null ? 0.0 : GoodsItem.Price * Quantity;
        }

        public override string ToString()
        {
            return $"[No.:{OrderDetailId},goods:{GoodsName},quantity:{Quantity},totalPrice:{TotalPrice}]";
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderDetail;
            return item != null &&
                   GoodsName == item.GoodsName;
        }

        public override int GetHashCode()
        {
            var hashCode = -2127770830;
            hashCode = hashCode * -1521134295 + OrderDetailId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsName);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
    }
}
