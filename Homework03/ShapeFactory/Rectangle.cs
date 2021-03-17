using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFactory
{
    internal class Rectangle: Shape
    {
        private double length;
        private double width;
        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
  
        public override double getArea()
        {
            if (!isLegal())
                return 0;
            return length * width;
        }

        public override bool isLegal()
        {
            return length > 0 && width > 0;
        }

        public override void show()
        {
            Console.WriteLine("This is a rectangle. Its area: {0}. It's legal? {1}", this.getArea().ToString("0.000"), this.isLegal());
        }
    }
}
