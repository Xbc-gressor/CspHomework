using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(12, 32);
            Shape square = new Square(12);
            Shape triangle = new Triangle(12, 32, 22);

            Console.WriteLine("The rectangle's area is: {0}; IsLegal: {1}", rectangle.Area, rectangle.IsLegal());
            Console.WriteLine("The square's area is: {0}; IsLegal: {1}", square.Area, square.IsLegal());
            Console.WriteLine("The triangle's area is: {0}; IsLegal: {1}", triangle.Area, triangle.IsLegal());

        }
    }
}
