using System;

namespace ColorChecker.Domain.Services.CustomExceptions
{
    public class ParsingPayloadException : Exception
    {
        public ParsingPayloadException(string message) : base(message) { }
    }
}
