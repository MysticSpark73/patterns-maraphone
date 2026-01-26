using Patterns.Memento.Vectors;

namespace Patterns.Memento.Checkers
{
    public class Board
    {
        private int _size;

        private int[,] _board;

        public Board(int size)
        {
            _size = size;
            _board = new int[_size, _size];
        }

        public bool IsOnBoard(Vector2Int position)
        {
            if (position.x < 0 || position.x >= _size) return false;
            if (position.y < 0 || position.y >= _size) return false;
            return true;
        }

        public BoardMemento CreateSnapshot()
        {
            return new BoardMemento(_size, _board);
        }

        public void RestoreState(BoardMemento memento)
        {
            _size = memento.Size;
            _board = memento.Board;
        }

        public void Setup()
        {
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if ((x + y) % 2 != 0) continue;
                    _board[x, y] = 1;
                }
            }
        }

        public BoardMemento MakeMove(Vector2Int from, Vector2Int to)
        {
            //todo: possibly add COR implementation here?
            if (!IsOnBoard(from) || !IsOnBoard(to))
            {
                return CreateSnapshot();
            }

            if (_board[from.x, from.y] == 0 || _board[to.x, to.y] == 1)
            {
                return CreateSnapshot();
            }
            
            //todo: validate move by direction and magnitude
            //todo: maybe make it TryMakeMove() with out memento value?

            _board[from.x, from.y] = 0;
            _board[to.x, to.y] = 1;

            return CreateSnapshot();
        }
    }
}