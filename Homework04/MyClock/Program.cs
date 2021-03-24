using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClock
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock myClock = new Clock("2021/3/24 16:36:00");
            myClock.StartTick();
        }
    }
}
