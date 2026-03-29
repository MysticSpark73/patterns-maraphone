namespace Patterns.State.Abilities.Data
{
    public class CastTime
    {
        public bool IsInstant => value.HasValue;
        public float? value;

        public override string ToString()
        {
            return value.HasValue ? value.Value.ToString("F2") :  "Instant";
        }
    }
}