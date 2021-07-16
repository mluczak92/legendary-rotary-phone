using System;

namespace legendary_rotary_phone.architecture
{
    public class RotaryException : Exception
    {
        public RotaryException(string message, string details) : base(message)
        {
            Details = details;
        }

        public int Status { get; } = 400;
        public string Details { get; }
    }
}
