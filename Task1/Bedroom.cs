using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Contracts;

namespace Tasks
{
    public class Bedroom : IRoom, IBedroom
    {
       public float Area
        {
            get; set;
        }
        public int Beds
        {
            get; set;
        }
        public int Chairs
        {
            get; set;
        }
    }
}
