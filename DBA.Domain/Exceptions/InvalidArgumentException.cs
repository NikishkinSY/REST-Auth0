using System;

namespace CTeleport.DBA.Domain.Exceptions
{
    public class InvalidArgumentException: Exception
    {
        public InvalidArgumentException(string message)
            : base(message)
        { }
    }
}
