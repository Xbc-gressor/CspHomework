﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    public class OrderDetail
    {
        public int index { get; set; }// 序号
        public Good good { get; set; }// 商品
        public int num { get; set; }  // 数量
        public double GTotalPrice => this.good.price * this.num;

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
