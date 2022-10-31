using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
    public class TV : Furniture
    {
        public bool TVOn { get; set; } = true;
        public override string Name
        {
            get { return "TV"; }
        }

        public override void Move()
        {
            
        }
        public void TurnOff ()
        {
            this.TVOn = false;
            Console.WriteLine("--TV is turned off--");
        }
        public void TurnOnn()
        {
            this.TVOn = true;
            Console.WriteLine("--TV is turned onn--");
        }
    }
}
