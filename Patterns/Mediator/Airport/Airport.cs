namespace Patterns.Mediator.Airport
{
    public class Airport
    {
        public List<TakeoffLine> _lines = new()
        {
            new TakeoffLine("A1", true, LineType.Long),
            new TakeoffLine("A2", false, LineType.Long),
            new TakeoffLine("A3", true, LineType.Long),
            new TakeoffLine("B1", false, LineType.Short),
            new TakeoffLine("B2", true, LineType.Short),
            new TakeoffLine("H1", false, LineType.Helipad),
            new TakeoffLine("H2", true, LineType.Helipad)
        };

        public void SetLineState(TakeoffLine takeoffLine, bool isAvailable)
        {
            for (int i = 0; i < _lines.Count; i++)
            {
                TakeoffLine line = _lines[i];
                if (string.CompareOrdinal(line.Name, takeoffLine.Name) == 0)
                {
                    line.IsAvailable = isAvailable;
                    _lines[i] = line;
                    return;
                }
            }
        }

        public TakeoffLine? GetAvailableLine(LineType type)
        {
            foreach (var line in _lines)
            {
                if (line.Type != type) continue;
                if (!line.IsAvailable) continue;
                return line;
            }

            return null;
        }
    }
}