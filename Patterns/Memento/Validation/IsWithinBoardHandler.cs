using Patterns.Memento.Checkers;
using Patterns.Memento.Vectors;

namespace Patterns.Memento.Validation
{
    public class IsWithinBoardHandler : ValidationHandlerBase
    {
        private Board _board;
        private Vector2Int _from;
        private Vector2Int _to;

        public IsWithinBoardHandler(Board board, Vector2Int from, Vector2Int to)
        {
            _board = board;
            _from = from;
            _to = to;
        }

        public override bool Handle()
        {
            if (IsWithinBoard())
            {
                return base.Handle();
            }
            
            Console.Out.WriteLine("Position is outside the board! {0}\n{1}",_from, _to);

            return false;
        }

        private bool IsWithinBoard() => _board.IsOnBoard(_from) && _board.IsOnBoard(_to);
    }
}