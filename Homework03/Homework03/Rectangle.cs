using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework03
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
        public double getArea()
        {
            if (!isLegal())
                return 0;
            return length * width;
        }

        public bool isLegal()
        {
            return length > 0 && width > 0;
        }
    }
}
