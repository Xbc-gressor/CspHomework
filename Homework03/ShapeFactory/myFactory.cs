using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFactory
{
    public class MyFactory
    {
        public static Shape ManuFacture(String type)
        {
            // 随机生成构造参数
            Random random = new Random((int)DateTime.Now.Ticks);
            double p1 = random.Next(-5, 20) + random.NextDouble();
            double p2 = random.Next(-5, 20) + random.NextDouble();
            double p3 = random.Next(-5, 20) + random.NextDouble();

            try
            {
                switch (type)
                {
                    case "Rectangle":
                        return new Rectangle(p1, p2);
                    case "Square":
                        return new Square(p1);
                    case "Triangle":
                        return new Triangle(p1, p2, p3);
                    default:
                        throw new ArgumentException();
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;

        }
    }
}
