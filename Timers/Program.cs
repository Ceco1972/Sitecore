using System;
using System.Threading;
using System.Timers;

namespace Timers
{
    class Program
    {
        public static void Main()
        {
            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(OnTimer);
            myTimer.Interval = 1000;
            myTimer.Enabled = true;
            myTimer.AutoReset = false;

            Console.WriteLine(@"Press 'q' and 'Enter' to quit...");

            while (Console.Read() != 'q')
            {
                Thread.Sleep(1000);
            }
        }

        public static void OnTimer(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("DateTime: " + DateTime.Now);
            System.Timers.Timer theTimer = (System.Timers.Timer)source;
            theTimer.Interval += 1000;
            theTimer.Enabled = true;
        }
    }
}

