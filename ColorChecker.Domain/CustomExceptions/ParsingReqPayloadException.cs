using System;

namespace ColorChecker.Domain.Services.CustomExceptions
{
    public class ParsingReqPayloadException : Exception
    {
        public ParsingReqPayloadException(string message) : base(message) { }
    }
}
