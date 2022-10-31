using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2._2
{
    public class Human
    {
       public Human (string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public void OnTrafficConducted(object source, TrafficLightsArgs tl)
        {
            Console.WriteLine("The lights has turned " + tl.Lights);
            if (tl.Lights==Lights.green)
            {
                Console.WriteLine($"{this.Name} can cross the street.");
            }
            else
            {
                Console.WriteLine($"{this.Name}, stop!");
            }
        }
    }
}
