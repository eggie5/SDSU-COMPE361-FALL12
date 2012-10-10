using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4SimonSays
{
    class InvalidStateException: System.Exception
    {
        private string p;

        public InvalidStateException(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
    }
}
