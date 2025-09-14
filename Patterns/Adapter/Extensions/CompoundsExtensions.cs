using System;
using Patterns.Adapter.Enums;

namespace Patterns.Adapter.Extensions
{
    public static class CompoundsExtensions
    {
        public static string ToString(this Chemicals chemical)
        {
            return chemical.ToString().ToLower();
        }

        public static string ToString(this CriticalPoint criticalPoint) => criticalPoint switch
        {
            CriticalPoint.MeltingPoint => "M",
            CriticalPoint.BoilingPoint => "B",
            _ => throw new ArgumentOutOfRangeException(nameof(criticalPoint), criticalPoint, $"There is no such type as {criticalPoint}")
        };
    }
}