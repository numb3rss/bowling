using System;

namespace Bowling.Infrastructure
{
    public class InfrastructureException : Exception
    {
        public InfrastructureException(string message) : base(message)
        {
            
        }
    }
}
