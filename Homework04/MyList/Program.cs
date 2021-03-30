using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] tList = { 12.1, 32.2, 22.2, 12.0, 10.0, 11.12 };
            GenericList<double> genericList = new GenericList<double>(tList);
            double max = double.NegativeInfinity, min = double.PositiveInfinity, sum = 0;

            Action<double> action = n => Console.Write(n + " ");
            action += n => { if (n > max) max = n; };
            action += n => { if (n < min) min = n; };
            action += n => { sum += n; };


            genericList.Foreach(action);

            Console.WriteLine($"\nmax value: {max}\nmin value: {min}\nsum      : {sum}\n");

        }
    }
}
