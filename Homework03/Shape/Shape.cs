using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    internal interface Shape
    {
        double Area { get; }
        bool IsLegal();
    }

    internal class Rectangle : Shape
    {
        private double Length { get; set; }
        private double Width { get; set; }
        public Rectangle(double length, double width)
        {
            this.Length = length;
            this.Width = width;
        }
        public double Area
        {
            get
            {
                if (!IsLegal())
                    return 0;
                return Length * Width;

            }

        }

        public bool IsLegal()
        {
            return Length > 0 && Width > 0;
        }
    }


    internal class Square : Rectangle
    {
        public Square(double side_length) : base(side_length, side_length)
        {
        }

    }

    internal class Triangle : Shape
    {
        private double side_1 { get; set; }
        private double side_2 { get; set; }
        private double side_3 { get; set; }

        public Triangle(double side_1, double side_2, double side_3)
        {
            this.side_1 = side_1; this.side_2 = side_2; this.side_3 = side_3;
        }

        // 当形状不合法时，面积返回0
        public double Area
        {
            get
            {
                if (!IsLegal())
                    return 0;
                double p = (side_1 + side_2 + side_3) / 2;
                return Math.Sqrt(p * (p - side_1) * (p - side_2) * (p - side_3));
            }

        }
        public bool IsLegal()
        {
            return side_1 > 0 && side_2 > 0 && side_3 > 0 && 
                side_1 + side_2 > side_3 &&
                side_2 + side_3 > side_1 &&
                side_3 + side_1 > side_2;

        }
    }
}
