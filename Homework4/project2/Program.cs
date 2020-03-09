using System;
using System.Threading;
/*2、使用事件机制，
* 模拟实现一个闹钟功能。
* 闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。
* 在闹钟走时时或者响铃时，在控制台显示提示信息。*/

namespace project2
{
    public delegate void TickHandler(object sender, ClockArgs e);
    public delegate void AlarmHandler(object sender, ClockArgs e);

    public class ClockArgs
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }

    class MyClock
    {
        public event TickHandler TickEvent;
        public event AlarmHandler AlarmEvent;
        public int AlarmHour { get; set; }
        public int AlarmMinute { get; set; }
        public int AlarmSecond { get; set; }

        public void TimeWentBy()
        {
            while (true)
            {
                int hour = DateTime.Now.Hour;
                int minute = DateTime.Now.Minute;
                int second = DateTime.Now.Second;
                ClockArgs args = new ClockArgs()
                {
                    Hour = hour,
                    Minute = minute,
                    Second = second
                };
                TickEvent(this, args);//触发tick事件
                if (AlarmHour == args.Hour && AlarmMinute == args.Minute && AlarmSecond == args.Second)
                    AlarmEvent(this, args);//触发alarm事件
                Thread.Sleep(1000);
            }
        }

        public void SetAlarm(int hour, int minute, int second)
        {
            AlarmHour = hour;
            AlarmMinute = minute;
            AlarmSecond = second;
        }
    }

    class ClockListener
    {
        public MyClock myClock = new MyClock();
        public ClockListener()
        {
            myClock.TickEvent += Tick;
            myClock.AlarmEvent += Alarm;
        }

        void Tick(object sender, ClockArgs args)
        {
            Console.WriteLine("DIDA~");
        }

        void Alarm(object sender, ClockArgs args)
        {
            Console.WriteLine("dilinglingling~~~" +
                $"It's {args.Hour}:{args.Minute}:{args.Second} right now");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ClockListener clockListener = new ClockListener();
            clockListener.myClock.SetAlarm(11, 52, 50);//自己修改
            clockListener.myClock.TimeWentBy();
        }
    }
}
