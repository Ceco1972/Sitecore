using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Contracts
{
    public interface IBedroom : IRoom
    {
        public int Beds { get; set; }
        public int Chairs { get; set; }

    }
}
