using System;
using System.IO;
using System.Threading;

namespace Pizza_for_everyone
{
    /*There is a birthday in a company.Someone bought a big pizza with 30 pieces.However,
     as the birthday boy is a hardcore software developer, he developed a few rules:
     It is possible for anyone to take any piece at any time.Even the same one at the same time.
     Everyone must log his/her name in the file in the following way:
     Name, number of taken pieces.
     Implement a console application that simulates this situation using threads. Let’s have 4 people.
     Additional notes:
     Make sure that the log files are not corrupted.
     Make an exception-safe application.*/


    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\User\Desktop\Sitecore\Record2.txt";

            Thread thread1 = new Thread(() =>
            {
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Thread.Sleep(1000);
                File.AppendAllText(filePath, name);

            });
            Thread thread2 = new Thread(() =>
            {
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Thread.Sleep(7000);
                File.AppendAllText(filePath, name);
            });
            Thread thread3 = new Thread(() =>
            {
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                Thread.Sleep(8000);
                File.AppendAllText(filePath, name);
            });
            Thread thread4 = new Thread(() =>
            {
                Console.WriteLine("Name: ");
                string name = Console.ReadLine();
                File.AppendAllText(filePath, name);
                Thread.Sleep(4000);

            });
            thread1.Start();
            thread1.Join();

            thread2.Start();
            thread2.Join();

            thread3.Start();
            thread3.Join();

            thread4.Start();
            thread4.Join();
        }
    }
}
