using System;
using HelloLibrary;
using System.Reflection;

namespace ReflectionTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly a = Assembly.LoadFrom("HelloLibrary.dll");
            Type[] types2 = a.GetTypes();
            //THIS ASSEMBLY HAS ONE INTERNAL CLASS (MagicClass)
            Console.WriteLine(types2[0].FullName);
            //TYPE T IS THIS CLASS
            Type t = types2[0];
           
            //GETTING THE INFO ABOUT THIS CLASS AND MANIPULATING THE VALUES
            //============================================================
            
            FieldInfo[] fi = t.GetFields(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            
            Console.WriteLine("// Static Fields");
            PrintMembers(fi);
           //----------------------------------
            //CHANGE FIELD VALUE VIA REFLECTION!!
            fi[0].SetValue(t, "Hello,");
           //-----------------------------------
            // Static properties.
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Properties");
            PrintMembers(pi);
            //pi[0].SetValue(t, "Hello,") - PROPERTY DOES NOT HAVE A SETTER;
            

            // Static events.
            EventInfo[] ei = t.GetEvents(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Events");
            PrintMembers(ei);

            // Static methods.
            MethodInfo[] mi = t.GetMethods(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            
            
            Console.WriteLine("// Static Methods");
            PrintMembers(mi);
            
            //CALL THE METHOD WHICH SETS THE MESSAGE
            object result = mi[1].Invoke(t, new object[] { " people!!!" });
           //OUTPUT OF THE VALUE RETURNED BY THE METHOD
            Console.WriteLine($"Here is the modified output: {result}");
           //TASK COMPLETED HERE
           //========================================================
            
            // Constructors.
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Instance |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Constructors");
            PrintMembers(ci);

            // Instance fields.
            fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Fields");
            PrintMembers(fi);

            // Instance properites.
            pi = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Properties");
            PrintMembers(pi);

            // Instance events.
            ei = t.GetEvents(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Events");
            PrintMembers(ei);

            // Instance methods.
            mi = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Public);
            Console.WriteLine("// Instance Methods");
            PrintMembers(mi);
            if (t.IsPublic)
            {
                Console.WriteLine("{0} is public.", t.FullName);
            }
            else
            {
                Console.WriteLine($"{t.FullName} is not public");
            }

            Console.WriteLine("\r\nPress ENTER to exit.");
            Console.Read();
        }

        public static void PrintMembers(MemberInfo[] ms)
        {
            foreach (MemberInfo m in ms)
            {
                Console.WriteLine("{0}{1}", "     ", m);
            }
            Console.WriteLine();
        }
    
    }
}
