using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        static int pizzaSlices = 30;
        private static object lockerFile = new Object();
        static string filePath = @"C:\Users\User\Desktop\Sitecore\Record2.txt";

       static void Main(string[] args)
        {
            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;
            int counter4 = 0;

            while (true)
            {
                try
                {
                    Task dev1 = Task.Run(() =>
                    {
                        Random rand = new Random();
                        int t = rand.Next(120000, 240000);
                        //Dev1 takes a pizza slice
                        //...and starts eating/not sleeping
                        while (Program.pizzaSlices > 0)
                        {
                            Console.WriteLine($"Dev 1 has just taken a slice");
                            counter1++;
                            Interlocked.Decrement(ref Program.pizzaSlices);

                            Thread.Sleep(t);
                        }
                    });
              Task dev2 = Task.Run(() =>
                {
                    Random rand = new Random();
                    int t = rand.Next(120000, 240000);
                    //Dev2 takes a pizza slice
                    //...and starts eating/not sleeping
                    while (Program.pizzaSlices > 0)
                    {
                        Console.WriteLine($"Dev 2 has just taken a slice");
                        counter2++;
                        Interlocked.Decrement(ref Program.pizzaSlices);
                        
                        Thread.Sleep(t);
                    }
                }); 
                Task dev3 = Task.Run(() =>
                {
                    Random rand = new Random();
                    int t = rand.Next(120000, 240000);
                    //Dev3 takes a pizza slice
                    //...and starts eating/not sleeping
                    while (Program.pizzaSlices > 0)
                    {
                        Console.WriteLine($"Dev 3 has just taken a slice");
                        Interlocked.Decrement(ref Program.pizzaSlices);
                        counter3++;
                       
                        Thread.Sleep(t);
                    }

                }); 
                Task dev4 = Task.Run(() =>
                {
                    Random rand = new Random();
                    int t = rand.Next(120000, 240000);
                    StringBuilder sb = new StringBuilder();
                    //Dev4 takes a pizza slice
                    //...and starts eating/not sleeping
                    while (Program.pizzaSlices > 0)
                    {
                        Console.WriteLine($"Dev 4 has just taken a slice");
                        Interlocked.Decrement(ref Program.pizzaSlices);
                        counter4++;
                        //lock (lockerFile)
                        //{
                        //  File.AppendAllText(filePath, "Dev4's slice");

                        //}
                        Thread.Sleep(t);
                    }

                });

                }
                catch (AggregateException)
                {

                    Console.WriteLine("Aggregate exception"); ;
                }

                if (Program.pizzaSlices==0)
                {
                    string counter1s = counter1.ToString();
                    string counter2s = counter2.ToString();
                    string counter3s = counter3.ToString();
                    string counter4s = counter4.ToString();

                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(filePath))
                        {
                            byte[] checkit = md5.ComputeHash(stream);
                        }
                    }

                    Console.WriteLine($"Pizza slices left: {Program.pizzaSlices}");

                    string path = @"C:\Users\User\Desktop\Sitecore\Record3.txt";

                    // Delete the file if it exists.
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    //Create the file.
                    using (FileStream fs = File.Create(path))
                    {
                        AddText(fs, "Dev1 slices: ");
                        AddText(fs, counter1s);
                        AddText(fs, "\r\nDev2 slices: ");
                        AddText(fs, counter2s);
                        AddText(fs, "\r\nDev3 slices: ");
                        AddText(fs, counter3s);
                        AddText(fs, "\r\nDev4 slices: ");
                        AddText(fs, counter4s);
                    }

                    //Open the stream and read it back.
                    using (FileStream fs = File.OpenRead(path))
                    {
                        byte[] b = new byte[1024];
                        UTF8Encoding temp = new UTF8Encoding(true);
                        int readLen;
                        while ((readLen = fs.Read(b, 0, b.Length)) > 0)
                        {
                            Console.WriteLine(temp.GetString(b, 0, readLen));
                        }
                    }
                

                static void AddText(FileStream fs, string value)
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(value);
                    fs.Write(info, 0, info.Length);
                }
/*

                File.AppendAllText(filePath, "Dev1's slices: ");
                    File.AppendAllText(filePath, counter1s);
                    File.AppendAllText(filePath, "   Dev2's slices: ");
                    File.AppendAllText(filePath, counter2s); 
                    File.AppendAllText(filePath, "   Dev3's slices: ");
                    File.AppendAllText(filePath, counter3s);
                    File.AppendAllText(filePath, "   Dev4's slices: ");
                    File.AppendAllText(filePath, counter4s);
*/
                    break;
                }
            }

        }
    }
}
