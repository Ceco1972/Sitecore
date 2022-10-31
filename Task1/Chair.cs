using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks
{
   public class Chair : Furniture
    {
        public override void Move()
        {
        }
        public override string Name 
        {
            get { return "Chair"; }
        }
    }
}
