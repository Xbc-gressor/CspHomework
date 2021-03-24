using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[10];

            // 测试无参随机生成器
            
            for(int i = 0; i < 10; i++)
            {
                try
                {
                    shapes[i] = MyFactory.ManuFacture();
                    shapes[i].Show();
                }
                catch(ArgumentException e)
                {
                    i -= 1; // 跳过不合法的形状
                    Console.WriteLine(e.Message);
                }
                
            }
            

            
            /*
            shapes[0] = MyFactory.ManuFacture("Rectangle", new double[] { 12 });
            shapes[1] = MyFactory.ManuFacture("Rectangle", new double[] { 12, 23 });
            shapes[2] = MyFactory.ManuFacture("Rectangle", new double[] { -2, 3 });
            shapes[3] = MyFactory.ManuFacture("Square", new double[] { 2 });
            shapes[4] = MyFactory.ManuFacture("Square", new double[] { 23, 12 });
            shapes[5] = MyFactory.ManuFacture("Triangle", new double[] { 12, 13 });
            shapes[6] = MyFactory.ManuFacture("Triangle", new double[] { 3, 4, 5 });
            shapes[7] = MyFactory.ManuFacture("Triangle", new double[] { 12, 2, 3 });
            shapes[8] = MyFactory.ManuFacture("Rec", new double[] { 12 });
            shapes[9] = MyFactory.ManuFacture("tangle", new double[] { 12 });
            */

            double sum = 0;
            foreach(Shape shape in shapes)
            {
                sum += shape.Area;
            }
            Console.WriteLine($"所有有效形状的面积和为{sum}");
        }
    }
}
