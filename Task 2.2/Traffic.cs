using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task_2._2
{
    public class TrafficLightsArgs : EventArgs
    {
        public Lights Lights { get; set; }
    }
    public class Traffic
    {
        public event EventHandler<TrafficLightsArgs> TrafficConducted;
        public void ChangeLight(Lights lights)
        {
            Console.WriteLine("Lights is changing...");
            Thread.Sleep(3000);
            Random rand = new Random();
            int l = rand.Next(0, 2);
            if (l==0)
            {
                lights = Lights.red;
            }
            else if (l==1)
            {
                lights = Lights.green;
            }
            OnTrafficConducted(lights);
        }
        protected virtual void OnTrafficConducted(Lights lights)
        {
            if (TrafficConducted!=null)
            {
                TrafficConducted(this, new TrafficLightsArgs() { Lights = lights });
            }
        }
    }
}
