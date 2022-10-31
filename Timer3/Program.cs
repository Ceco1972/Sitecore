using System;
using System.Timers;

namespace Timer3
{
    class Program
    {
        static void Main(string[] args)
        {
            var keyPressed = false;
            const int delay = 1000;         //Define the delay for the Timer
            var timer = new Timer(delay);   //Create the Timer
            timer.Elapsed += Timer_Elapsed; //Set the Timer event
            timer.Enabled = true;           //Start the Timer

            Console.WriteLine("Press any key to stop...");

            while (!keyPressed)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key != null) keyPressed = true;
            }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Do something when we reached the Delay of the Timer
            Console.Write($"\r{DateTime.Now}"); // \r to rewrite on the same line
        }
    }
}

