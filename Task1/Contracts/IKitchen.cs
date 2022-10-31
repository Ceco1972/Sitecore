using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Contracts
{
    public interface IKitchen : IRoom
    {
        public int Table { get; set; }
        public int Chairs { get; set; }
    }
}
