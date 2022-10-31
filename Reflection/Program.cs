using System;
using System.Reflection;

namespace Reflection  
{
    class Program
    {
        static void Main(string[] args)
        {

            Type type = typeof(System.String);
            Console.WriteLine(type);
            ConstructorInfo[] ci = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("//Constructors");
            PrintMembers(ci);
        }
            public static void PrintMembers(MemberInfo[] ms)
        {
            foreach (MemberInfo m in ms)
            {
                Console.WriteLine("{0}{1}", "  ", m);
            }
        }
            //MemberInfo[] members = type.GetMembers();
            //foreach (var item in members)
            //{
            //    Console.WriteLine(item);

            //}

           // Assembly info = typeof(int).Assembly;
            //Console.WriteLine(info);
        
    }
}
