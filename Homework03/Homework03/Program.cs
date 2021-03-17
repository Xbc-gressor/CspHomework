using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Homework03
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape rectangle = new Rectangle(12, 32);
            Shape square = new Square(12);
            Shape triangle = new Triangle(12, 32, 22);

            Console.WriteLine("The rectangle's area is: {0}; IsLegal: {1}", rectangle.getArea(), rectangle.isLegal());
            Console.WriteLine("The square's area is: {0}; IsLegal: {1}", square.getArea(), square.isLegal());
            Console.WriteLine("The triangle's area is: {0}; IsLegal: {1}", triangle.getArea(), triangle.isLegal());

        }
    }


}
