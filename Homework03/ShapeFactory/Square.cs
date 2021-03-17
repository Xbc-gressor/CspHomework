using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFactory
{
    internal class Square: Rectangle
    {
        public Square(double side_length) : base(side_length, side_length)
        {
        }

        public override void show()
        {

            Console.WriteLine("This is a square. Its area: {0}. It's legal? {1}", this.getArea().ToString("0.000"), this.isLegal());
        
        }
    }
}
