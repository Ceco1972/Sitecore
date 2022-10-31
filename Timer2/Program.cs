using System;
using System.Timers;

namespace Timer2
{
    class Program
    {
        public static void Main()
        {
            Timer newTimer = new Timer();
            newTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            newTimer.Interval = 2000;
            newTimer.Start();
            while (Console.Read() != 'q')
            {
                ;    // we can write anything here if we want, leaving this part blank won’t bother the code execution.
            }
        }
        public static void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            Console.Write(" \r{0} ", DateTime.Now);
        }
    }
}

