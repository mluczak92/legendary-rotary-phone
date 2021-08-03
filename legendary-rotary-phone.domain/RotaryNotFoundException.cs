namespace legendary_rotary_phone.domain
{
    public class RotaryNotFoundException<T> : RotaryException
    {
        public RotaryNotFoundException(int id)
            : base($"Resource of type {typeof(T).Name} with Id = {id} not found")
        {

        }

        public override int Status { get; protected set; } = 404;
    }
}
