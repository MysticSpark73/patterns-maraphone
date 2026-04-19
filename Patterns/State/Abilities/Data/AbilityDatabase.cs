using Patterns.State.Abilities.Warlock;
using Patterns.State.Classes.Data;

namespace Patterns.State.Abilities.Data
{
    public static class AbilityDatabase
    {
        private static Dictionary<Type, AbilityData> Abilities = new ()
        {
            {
                typeof(Corruption), new AbilityData
                {
                    name = AbilityNames.Warlock.Corruption,
                    castTime = CastTime.Instant,
                    channelDuration = ChannelDuration.Instant,
                    duration = new AbilityDuration(14),
                    cooldown = 1,
                    requiredClass = ClassType.Warlock
                }
            },
            {
                typeof(DrainSoul), new AbilityData()
                {
                    name = AbilityNames.Warlock.DrainSoul,
                    castTime =  CastTime.Instant,
                    channelDuration = new ChannelDuration(5),
                    duration = AbilityDuration.None,
                    cooldown = 1,
                    requiredClass = ClassType.Warlock
                }
            },
            {
                typeof(Haunt), new AbilityData()
                {
                    name = AbilityNames.Warlock.Haunt,
                    castTime = new CastTime(1.5f),
                    channelDuration = ChannelDuration.Instant,
                    duration = new AbilityDuration(18),
                    cooldown = 1.5f,
                    requiredClass = ClassType.Warlock
                }
            },
            {
                typeof(Malevolence), new AbilityData()
                {
                    name = AbilityNames.Warlock.Malevolence,
                    castTime = CastTime.Instant,
                    channelDuration = ChannelDuration.Instant,
                    duration = new AbilityDuration(20),
                    cooldown = 60,
                    requiredClass = ClassType.Warlock
                }
            }
        };
        
        public static class AbilityNames
        {
            public static class Warlock
            {
                public const string Corruption = "Corruption";
                public const string DrainSoul = "Drain Soul";
                public const string Haunt = "Haunt";
                public const string Malevolence = "Malevolence";
            }
        }

        public static AbilityData? GetAbilityData(Type type)
        {
            if (!Abilities.ContainsKey(type))
            {
                Console.Out.WriteLine($"Can't find AbilityData for type {type}");
                return null;
            }

            return Abilities[type];
        }
    }
}