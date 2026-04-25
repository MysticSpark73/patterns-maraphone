namespace Patterns.State.Abilities.Data
{
    public class CastTime
    {
        public static CastTime Instant => new (null);
        public bool IsInstant => !(value.HasValue && value.Value > 0);
        public float? value;
        
        public CastTime(float? value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value.HasValue ? value.Value.ToString("F2") :  "Instant";
        }
    }
}