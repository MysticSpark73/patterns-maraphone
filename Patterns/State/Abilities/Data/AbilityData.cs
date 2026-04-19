using Patterns.State.Classes.Data;

namespace Patterns.State.Abilities.Data
{
    public class AbilityData
    {
        public string name;
        public CastTime castTime;
        public ChannelDuration channelDuration;
        public AbilityDuration duration;
        public float cooldown;
        public bool IsAffectedByGlobalCooldown = true;
        public ClassType requiredClass;
    }
}