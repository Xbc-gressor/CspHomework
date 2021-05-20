using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class Good
    {
        public string GoodId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Good()
        {
            GoodId = Guid.NewGuid().ToString();
        }
        public Good(string goodName, double price): this()
        {

            this.Name = goodName;
            this.Price = price;
        }

        public override bool Equals(object obj)
        {
            var goods = obj as Good;
            return goods != null &&
                   GoodId == goods.GoodId &&
                   Name == goods.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 1479869798;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GoodId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }

        public override string ToString()
        {
            return Name.PadLeft(20) + Price.ToString().PadLeft(20);
        }
    }
}
