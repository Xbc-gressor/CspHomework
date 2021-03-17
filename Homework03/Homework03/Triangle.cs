﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework03
{
    internal class Triangle: Shape
    {
        private double side_1;
        private double side_2;
        private double side_3;

        public Triangle(double side_1, double side_2, double side_3)
        {
            this.side_1 = side_1; this.side_2 = side_2; this.side_3 = side_3;
        }
        public double getArea()
        {
            if (!isLegal())
                return 0;
            double p = (side_1 + side_2 + side_3) / 2;
            return Math.Sqrt(p * (p - side_1) * (p - side_2) * (p - side_3));
        }
        public bool isLegal()
        {
            return (side_1 + side_2 > side_3 &&
                side_2 + side_3 > side_1 &&
                side_3 + side_1 > side_2);
    
        }
    }
}
