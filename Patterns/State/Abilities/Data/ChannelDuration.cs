namespace Patterns.State.Abilities.Data
{
    public class ChannelDuration
    {
        public static ChannelDuration Instant => new(null);
        
        public float? value;

        public ChannelDuration(float? value)
        {
            this.value = value;
        }

        public bool IsChannelable => value.HasValue;

        public override string ToString()
        {
            return value.HasValue ? value.Value.ToString("F2") : "No";
        }
    }
}