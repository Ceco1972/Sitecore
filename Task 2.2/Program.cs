using System;
using System.Collections;
using System.Collections.Generic;

namespace Task_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Human ivan = new Human("Ivan");
            Human peter = new Human("Peter");
            List<Human> people = new List<Human>();
            people.Add(ivan);
            people.Add(peter);
            
            var lights = new Lights();
            var traffic = new Traffic();

            foreach (var person in people)
            {
                traffic.TrafficConducted += person.OnTrafficConducted;
            }

            traffic.ChangeLight(lights);




        }
    }
}
