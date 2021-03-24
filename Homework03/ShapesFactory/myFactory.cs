using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesFactory
{
    class MyFactory
    {
        static Random ran = new Random();

        // 无参形式，只会生成合法图形，否则会抛出异常
        public static Shape ManuFacture()
        {
            int type = ran.Next(1, 4);
            Shape shape = null;
            switch (type)
            {
                case 1:
                    shape = new Rectangle(ran.Next(-10, 20) + ran.NextDouble(), ran.Next(-10, 20) + ran.NextDouble());
                    if (shape.IsLegal) return shape;                  
                    else throw new ArgumentException("生成了不合法的矩形！");                  
                case 2:
                    shape = new Square(ran.Next(-10, 20) + ran.NextDouble());
                    if (shape.IsLegal) return shape;
                    else throw new ArgumentException("生成了不合法的正方形！");
                case 3:
                    shape = new Triangle(ran.Next(-10, 20) + ran.NextDouble(), ran.Next(-10, 20) + ran.NextDouble(), ran.Next(-10, 20) + ran.NextDouble());
                    if (shape.IsLegal) return shape;
                    else throw new ArgumentException("生成了不合法的三角形！");
                default:
                    throw new ArgumentException();
            }
        }

        public static Shape ManuFacture(String type, double[] paras)
        {
            Shape shape = null;
            switch (type)
            {
                case "Rectangle":
                    if (paras.Length != 2)
                    {
                        throw new ArgumentException($"参数数量错误，需要2个参数，但是获得了{paras.Length}个！");
                    }
                    shape = new Rectangle(paras[0], paras[1]);
                    if (shape.IsLegal) return shape;
                    else throw new ArgumentException("生成了不合法的矩形！");
                case "Square":
                    if (paras.Length != 1)
                    {
                        throw new ArgumentException($"参数数量错误，需要1个参数，但是获得了{paras.Length}个！");
                    }
                    shape =  new Square(paras[0]);
                    if (shape.IsLegal) return shape;
                    else throw new ArgumentException("生成了不合法的正方形！");
                case "Triangle":
                    if (paras.Length != 3)
                    {
                        throw new ArgumentException($"参数数量错误，需要3个参数，但是获得了{paras.Length}个！");
                    }
                    shape =  new Triangle(paras[0], paras[1], paras[2]);
                    if (shape.IsLegal) return shape;
                    else throw new ArgumentException("生成了不合法的三角形！");
                default:
                    throw new ArgumentException("不存在的形状");
            }
        }
    }
}
