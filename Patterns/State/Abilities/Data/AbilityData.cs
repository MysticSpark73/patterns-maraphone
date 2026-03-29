namespace Patterns.State.Abilities.Data
{
    public class AbilityData
    {
        public string name;
        public CastTime castTime;
        public ChannelDuration channelDuration;
        public float cooldown;
        public bool IsAffectedByGlobalCooldown;
    }
}