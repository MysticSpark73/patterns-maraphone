namespace Patterns.Prototype.Enums
{
    public enum CellType : byte
    {
        // Generic
        Stem = 0,
    
        // Skin
        Epidermal = 1,

        // Muscle
        SkeletalMuscle = 2,
        CardiacMuscle = 3,
        SmoothMuscle = 4,

        // Nerve
        Neuron = 5,

        // Blood
        RedBloodCell = 6,
        WhiteBloodCell = 7,

        // Immune
        Macrophage = 8,
        TCell = 9,

        // Bone & Connective
        Osteocyte = 10,
        Osteoclast = 11,
    
        Bacteria = 12
    
    }
}