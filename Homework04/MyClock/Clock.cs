using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyClock
{
    public delegate void ClockHandler(object sender, TickEventArgs args);
    public class TickEventArgs
    {
        public int[] Target { get; set; }
    }
    public class Clock
    {
        // 定义事件
        public event ClockHandler Tick;
        public event ClockHandler Alarm;

        // 设定的闹钟
        private int[] alarmTime;
        private int[] currentTime = new int[3];

        public Clock(int[] alarmTime)
        {
            this.alarmTime = alarmTime;
            this.Tick = TickEv;
            this.Alarm = AlarmEv;
        }
        public void StartTick()
        {
            Console.WriteLine("闹钟开启:");
            TickEventArgs args = new TickEventArgs() {Target = this.alarmTime };
            Tick(this, args);
        }


        void TickEv(object sender, TickEventArgs args)
        {
            this.currentTime[0] = DateTime.Now.Hour;
            this.currentTime[1] = DateTime.Now.Minute;
            this.currentTime[2] = DateTime.Now.Second;
            if (currentTime[0] == args.Target[0] && currentTime[1] == args.Target[1] && currentTime[2] == args.Target[2])
            {
                this.Alarm(this, args);
            }
            else
            {
                Console.WriteLine($"{DateTime.Now.ToLongDateString().ToString()} " +
                    $"{currentTime[0].ToString().PadLeft(2, '0')}:" +
                    $"{currentTime[1].ToString().PadLeft(2, '0')}:" +
                    $"{currentTime[2].ToString().PadLeft(2,'0')}");
            }

            currentTime[2] = (currentTime[2] + 1) % 60;
            currentTime[1] = (currentTime[1] + currentTime[2] == 0 ? 1 : 0) % 60;
            currentTime[0] = (currentTime[0] + (currentTime[1] + currentTime[2]) == 0 ? 1 : 0) % 24;
            Thread.Sleep(1000);

            this.Tick(this, args);
        }

        void AlarmEv(object sender, TickEventArgs args)
        {
            Console.WriteLine("Time is up! Time is up!");
        }
    }
}
