using System.Numerics;

namespace Patterns.Memento.Validation
{
    public class DirectionValidationHandler : ValidationHandlerBase
    {
        private Vector2 _direction;

        public DirectionValidationHandler(Vector2 direction)
        {
            _direction = direction;
        }

        public override bool Handle()
        {
            if (IsDirectionValid())
            {
                return base.Handle();
            }

            Console.Out.WriteLine("Direction {0} is invalid", _direction);
            return false;
        }

        private bool IsDirectionValid()
        {
            if (_direction.X == 0 || _direction.Y == 0) 
            {
                return false;
            }

            return true;
        }
    }
}