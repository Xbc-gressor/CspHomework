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
        public String Target { get; set; }
    }
    public class Clock
    {
        // 定义事件
        public event ClockHandler Tick;
        public event ClockHandler Alarm;

        // 设定的闹钟
        private String TargetTime { get; set; }

        public Clock(String target)
        {
            this.TargetTime = target;
            this.Tick = TickEv;
            this.Alarm = AlarmEv;
        }
        public void StartTick()
        {
            Console.WriteLine("闹钟开启:");
            TickEventArgs args = new TickEventArgs() {Target = this.TargetTime };
            Tick(this, args);
        }


        void TickEv(object sender, TickEventArgs args)
        {
            String nowTime = DateTime.Now.ToString();
            if (nowTime == args.Target)
            {
                this.Alarm(this, args);
            }
            else
            {
                Console.WriteLine(nowTime);
            }
            Thread.Sleep(1000);

            this.Tick(this, args);
        }

        void AlarmEv(object sender, TickEventArgs args)
        {
            Console.WriteLine("Time is up! Time is up!");
        }
    }
}
