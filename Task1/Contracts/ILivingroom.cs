using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Contracts
{
    public interface ILivingroom : IRoom
    {
        public int Couch { get; set; }
        public string CouchColour { get; set; }
        public int Chairs { get; set; }
        public int TV { get; set; }

    }
}
