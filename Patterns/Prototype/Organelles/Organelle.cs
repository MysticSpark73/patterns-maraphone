using Patterns.Prototype.Interfaces;

namespace Patterns.Prototype.Organelles;

public class Organelle : ICloneable<Organelle>
{
    public virtual Organelle Clone()
    {
        return new Organelle();
    }

    public virtual void UpdateState()
    {
        
    }

    public virtual int GetEnergyLevel()
    {
        return 0;
    }
}