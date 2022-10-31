using System;

namespace DotNetEXERCISES
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] values = { 100, 17111.8 };
           
                Type tp1 = values[0].GetType();
            Type tp2 = values[1].GetType();

                Console.WriteLine("{0}  ", tp1);

                Console.WriteLine("'{0}'  ", tp2 );
            
        }
    }
}