using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeFactory
{
    public abstract class Shape
    {
        public abstract double getArea();
        public abstract bool isLegal();
        public abstract void show();
    }
}
