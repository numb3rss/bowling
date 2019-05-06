using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Host
{
    public class HostException : Exception
    {
        public HostException(string message) : base(message)
        {
            
        }
    }
}
