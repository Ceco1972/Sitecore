using System;
using System.Threading;
using System.Threading.Tasks;

namespace TryEnterMonitorTaskDeadlock
{
    class Program
    {
        static readonly object knife = 1;
        static readonly object cuttingBoard = 1;
        static bool lockTaken = false;
        static bool lockTaken2 = false;
        static bool lockTaken3 = false;
        static bool lockTaken4 = false;
        static void Mom()
        {
            try
            {
                Monitor.TryEnter(Program.knife, 1000, ref lockTaken);
                if (lockTaken)
                {
                    Cutting();
                }
                else
                {
                    Console.WriteLine("No knife for mom..");
                }
            }
            finally
            {
                // Ensure that the lock is released.
                if (lockTaken)
                {
                    Monitor.Exit(Program.knife);
                    lockTaken = false;
                }
            }
        }
        static void Cutting()
        {
            try
            {
                Monitor.TryEnter(Program.cuttingBoard, ref lockTaken2);
                if (lockTaken2)
                {
                    Console.WriteLine("Mom working with knife and cuttingboard now.");
                }
                else
                {
                    Console.WriteLine("No cutting board available now..");
                }
            }
            finally
            {
                // Ensure that the lock is released.
                if (lockTaken2)
                {
                    Monitor.Exit(Program.cuttingBoard);
                    Console.WriteLine("Mom has finished");
                    lockTaken2 = false;
                }

            }
        }
        static void Wife()
        {
            try
            {
                Monitor.TryEnter(Program.knife, 1000, ref lockTaken3);
                if (lockTaken3)
                {
                    Cutting2();
                }
                else
                {
                    Console.WriteLine("No knife for wife..");
                }
            }
            finally
            {
                // Ensure that the lock is released.
                if (lockTaken3)
                {
                    Monitor.Exit(Program.knife);
                    lockTaken3 = false;
                }
            }

        }
        static void Cutting2()
        {
            try
            {
                Monitor.TryEnter(Program.cuttingBoard, ref lockTaken4);
                if (lockTaken4)
                {
                    Console.WriteLine("Wife working with knife and cuttingboard now.");
                }
                else
                {
                    Console.WriteLine("No cutting board for wife..");
                }
            }
            finally
            {
                // Ensure that the lock is released.
                if (lockTaken4)
                {
                    Monitor.Exit(Program.cuttingBoard);
                    Console.WriteLine("Wife has finished.");
                    lockTaken4 = false;
                }
            }
        }
        static void Main(string[] args)
        {
                       //Thread wife = new Thread(new ThreadStart(Wife));
            //wife.Start();
            //TaskWife();
            Task wife = Task.Run(() =>
            {
                try
                {
                    Monitor.TryEnter(Program.knife,1000, ref lockTaken3);
                    if (lockTaken3)
                    {
                        Console.WriteLine("Wife has got the knife.");
                        try
                        {
                            Monitor.TryEnter(Program.cuttingBoard, 1000, ref lockTaken4);
                            if (lockTaken4)
                            {
                                Console.WriteLine("Wife working with knife and cuttingboard now.");
                            }
                            else
                            {
                                Console.WriteLine("No cutting board for wife..");
                            }
                        }
                        finally
                        {
                            // Ensure that the lock is released.
                            if (lockTaken4)
                            {
                                Monitor.Exit(Program.cuttingBoard);
                                Console.WriteLine("Wife has finished.");
                                lockTaken4 = false;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("No knife for wife..");
                    }
                }
                finally
                {
                    // Ensure that the lock is released.
                    if (lockTaken3)
                    {
                        Monitor.Exit(Program.knife);
                        lockTaken3 = false;
                    }
                }
            });

            Thread mother = new Thread(new ThreadStart(Mom));
            mother.Start();

        }
        static void TaskWife()
        {
            Task wife = Task.Run(() =>
            {
                try
                {
                    Monitor.TryEnter(Program.knife, 1000, ref lockTaken3);
                    if (lockTaken3)
                    {
                        Console.WriteLine("Wife has got the knife.");
                        try
                        {
                            Monitor.TryEnter(Program.cuttingBoard, ref lockTaken4);
                            if (lockTaken4)
                            {
                                Console.WriteLine("Wife working with knife and cuttingboard now.");
                            }
                            else
                            {
                                Console.WriteLine("No cutting board for wife..");
                            }
                        }
                        finally
                        {
                            // Ensure that the lock is released.
                            if (lockTaken4)
                            {
                                Monitor.Exit(Program.cuttingBoard);
                                Console.WriteLine("Wife has finished.");
                                lockTaken4 = false;
                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine("No knife for wife..");
                    }
                }
                finally
                {
                    // Ensure that the lock is released.
                    if (lockTaken3)
                    {
                        Monitor.Exit(Program.knife);
                        lockTaken3 = false;
                    }
                }
            });
        }
    }

}

