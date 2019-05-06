using System;

namespace Bowling.Application
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message)
        {
            
        }
    }
}
