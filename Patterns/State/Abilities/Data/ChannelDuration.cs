namespace Patterns.State.Abilities.Data
{
    public class ChannelDuration
    {
        public float? value;

        public bool IsChannelable => value.HasValue;

        public override string ToString()
        {
            return value.HasValue ? value.Value.ToString("F2") : "No";
        }
    }
}