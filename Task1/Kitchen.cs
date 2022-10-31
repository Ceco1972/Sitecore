using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Contracts;

namespace Tasks
{
    public class Kitchen : IRoom, IKitchen
    {
        public float Area
        {
            get; set;
        }
        public int Chairs
        {
            get; set;
        }
        public int Table
        {
            get; set;
        }
    }
}
