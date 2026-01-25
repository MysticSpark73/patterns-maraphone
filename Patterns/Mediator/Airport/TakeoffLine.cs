namespace Patterns.Mediator.Airport
{
    public struct TakeoffLine
    {
        public string Name;
        public bool IsAvailable;
        public LineType Type;

        public TakeoffLine(string name, bool isAvailable, LineType type)
        {
            Name = name;
            IsAvailable = isAvailable;
            Type = type;
        }
    }
}