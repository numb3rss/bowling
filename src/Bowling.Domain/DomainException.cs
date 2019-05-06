using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
            
        }
    }
}
