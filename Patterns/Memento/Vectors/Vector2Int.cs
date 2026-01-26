using System.Numerics;

namespace Patterns.Memento.Vectors
{
    public class Vector2Int
    {
        public int x, y;
        public float magnitude => MathF.Sqrt(MathF.Pow(x, 2) + MathF.Pow(y, 2));

        public float sqrMagnitude => MathF.Pow(x, 2) + MathF.Pow(y, 2);

        public Vector2 normalized => new Vector2((float) x / magnitude, (float) y / magnitude);
        
        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}