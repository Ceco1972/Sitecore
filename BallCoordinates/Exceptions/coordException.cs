using System;
using System.Collections.Generic;
using System.Text;

namespace BallCoordinates.Exceptions
{
    class CoordException : ArgumentException
    {
        private string err_msg;
        public CoordException(string message)
        {
            this.err_msg = message;
        }

        public override string Message
        {
            get
            {
                return err_msg;
            }
        }
    }
}
