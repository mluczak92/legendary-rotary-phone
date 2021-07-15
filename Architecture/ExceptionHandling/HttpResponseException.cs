using System;

namespace legendary_rotary_phone.Architecture.ExceptionHandling
{
    public class HttpResponseException : Exception
    {
        public int Status { get; protected set; } = 400;
        public string Description { get; protected set; } 
    }
}
