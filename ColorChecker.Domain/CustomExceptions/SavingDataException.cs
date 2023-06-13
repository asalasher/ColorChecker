using System;

namespace ColorChecker.Domain.Services.CustomExceptions
{
    public class SavingDataException : Exception
    {
        public SavingDataException(string message) : base(message) { }
    }
}
