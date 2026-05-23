using Patterns.Strategy.Firearms;
using Patterns.Strategy.Firearms.Data;

namespace Patterns.Strategy
{
    public static class FirearmDataProvider
    {
        private static readonly Dictionary<Type, FirearmData> FirearmData = new()
        {
            { typeof(Pistol), new() { magazineCapacity = 7, burstSize = 0 } },
            { typeof(AssaultRifle), new() { magazineCapacity = 30, burstSize = 3 } },
            { typeof(Rifle), new (){magazineCapacity = 5, burstSize = 0} },
            { typeof(Shotgun), new (){ magazineCapacity = 2, burstSize = 0} }
        };

        public static FirearmData? GetData<T>() where T : Firearm
        {
            if (FirearmData.ContainsKey(typeof(T)))
            {
                return FirearmData[typeof(T)];
            }

            return null;
        }
    }
}