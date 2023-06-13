using System;

namespace ColorChecker.Domain.CustomExceptions
{
    public class DataBaseException : Exception
    {
        public DataBaseException(string message) : base(message)
        {

        }
    }
}
