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
            int[] alarmTime = new int[3];

            Console.WriteLine("请设置闹钟(HH:MM:SS)：");
            while (true)
            {
                try
                {
                    var time = Console.ReadLine()?.Trim().Split(':');
                    var timeList = Array.ConvertAll(time, int.Parse);
                    if (timeList.Length != 3)
                        throw new ArgumentException("时间格式错误!");
                    if (timeList[0] < 0 || timeList[0] > 23 || timeList[1] < 0 || timeList[1] > 59 || timeList[2] < 0 || timeList[2] > 59)
                        throw new ArgumentException("无效的时间!");
                       
                    alarmTime = timeList;
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("请重新输入(HH:MM:SS)：");
                }

            }
            Clock myClock = new Clock(alarmTime);
            myClock.StartTick();
        }
    }
}
