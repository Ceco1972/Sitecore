using System;
using Country2;

namespace TaxCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which country? ");
            string country = Console.ReadLine();
            Console.WriteLine("Salary? ");
            int salary = int.Parse(Console.ReadLine());
            Console.WriteLine("Salary with Tax: {0}", taxSalary(country, salary));
        }
       public static int taxSalary (string country, int sal)
        {
            Class1 cal = new Class1();
            int result = cal.TaxValue(country) * sal / 100 + sal;
            return result;
        }
    }
}
