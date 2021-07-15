using System;

namespace legendary_rotary_phone.Architecture.ExceptionHandling
{
    public class HttpResponseException : Exception
    {
        public HttpResponseException(string message, string details) : base(message)
        {
            Details = details;
        }

        public int Status { get; } = 400;
        public string Details { get; }
    }
}
