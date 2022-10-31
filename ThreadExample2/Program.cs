using System;
using System.Threading;

namespace ThreadExample2
{
    class Program

    {

        static void Show_Left(DateTime dt)

        {

            TimeSpan duration = new TimeSpan(0, 2, 0);

            TimeSpan ts = DateTime.Now - dt;

            TimeSpan left = duration - ts;

            Console.WriteLine("[{0:00}:{1:00}:{2:00}]", left.Hours, left.Minutes, left.Seconds);

        }



        static void Times_up(object thread)

        {

            Thread t = (Thread)thread;

            Console.WriteLine("\nTime's Up!");

            t.Abort();

        }



        static void Do_Work(object starttime)

        {

            DateTime StartTime = (DateTime)starttime;

            Console.WriteLine("Start!");

            Console.Write("Q1:blablabla?");

            Show_Left(StartTime);

            string input1 = Console.ReadLine();
            Console.WriteLine($"Your answer is: {input1}");

            Console.Write("Q2:blablabla?");

            Show_Left(StartTime);

            Console.ReadLine();

            Console.Write("Q3:blablabla?");

            Show_Left(StartTime);

            Console.ReadLine();

            Console.WriteLine("Done!");

        }



        static void Main(string[] args)

        {

            Thread work = new Thread(Do_Work);

            Timer timer = new Timer(Times_up, work, 120000, Timeout.Infinite);

            DateTime StartTime = DateTime.Now;

            work.Start(StartTime);

            work.Join();

            Console.Write("End");

            Show_Left(StartTime);

            timer.Dispose();

            Console.Read();

        }

    }
}
