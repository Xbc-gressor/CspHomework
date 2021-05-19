using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp
{
    public class Goods
    {
        public string GoodsId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        private static int index = 0;

        public Goods()
        {
            GoodsId = index.ToString();
            index += 1;
        }

        public Goods(string name, double price): this()
        {
            Name = name;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null &&
                   GoodsId == goods.GoodsId &&
                   Name == goods.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodsId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }


}
