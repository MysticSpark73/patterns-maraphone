using Patterns.Memento.Checkers;
using Patterns.Memento.Vectors;

namespace Patterns.Memento.Validation
{
    public class IsNotEmptyHandler : ValidationHandlerBase
    {
        private Board _board;
        private Vector2Int _from;
        private Vector2Int _to;

        public IsNotEmptyHandler(Board board, Vector2Int from, Vector2Int to)
        {
            _board = board;
            _from = from;
            _to = to;
        }

        public override bool Handle()
        {
            if (CanMovePiece())
            {
                return base.Handle();
            }
            
            Console.Out.WriteLine("Can't move {0} to the position {1}", _from, _to);
            return false;
        }

        private bool CanMovePiece() => !_board.IsEmpty(_from) && _board.IsEmpty(_to);
    }
}