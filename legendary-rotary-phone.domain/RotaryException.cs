using System;

namespace legendary_rotary_phone.domain
{
    public class RotaryException : Exception
    {
        public RotaryException(string message) : base(message)
        {

        }

        public virtual int Status { get; protected set; } = 400;
    }
}
