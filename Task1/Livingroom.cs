using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Contracts;

namespace Tasks
{
    public class Livingroom :IRoom, ILivingroom
    {
        public float Area
        {
            get; set;
        }
        public int Couch
        {
            get; set;
        }
        public string CouchColour
        {
            get; set;
        }
        public int Chairs
        {
            get; set;
        }
        public int TV
        {
            get; set;
        }
    }
}
