namespace Patterns.State.Abilities.Data
{
    public class AbilityDuration
    {
        public static AbilityDuration None = new (null);
        
        public float? value;
        public bool HasDuration => value.HasValue && value.Value > 0;

        public AbilityDuration(float? value)
        {
            this.value = value;
        }
    }
}