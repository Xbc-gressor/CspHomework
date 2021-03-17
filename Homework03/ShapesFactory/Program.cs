using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ShapeFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            Shape[] shapes = new Shape[10];
            double sum = 0;
            for (int i = 0; i < 10; i++)
            {
                int type = random.Next(1, 4);
                switch (type)
                {
                    case 1:
                        shapes[i] = MyFactory.ManuFacture("Rectangle"); break;
                    case 2:
                        shapes[i] = MyFactory.ManuFacture("Square"); break;
                    case 3:
                        shapes[i] = MyFactory.ManuFacture("Triangle"); break;
                    default:
                        throw new ArgumentException();                 
                }

                shapes[i].show();
                sum += shapes[i].getArea();

                // 延迟300ms
                Thread.Sleep(300);
            }

            Console.WriteLine("The total area of the ten shapes is " + sum.ToString("0.000"));
        }
    }
}
