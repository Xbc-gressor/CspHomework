using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement
{
    [Serializable]
    public class Good
    {

        public string goodName = "";// 货物名字，唯一标定货物
        public double price = 0;

        public Good()
        {

        }
        public Good(string goodName, double price)
        {

            this.goodName = goodName;
            this.price = price;
        }

        public override bool Equals(object obj)
        {
            return obj is Good good &&
                   goodName.ToLower() == good.goodName.ToLower();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(goodName.ToLower());
        }

        public override string ToString()
        {
            return goodName.PadLeft(20) + price.ToString().PadLeft(20);
        }
    }
}














