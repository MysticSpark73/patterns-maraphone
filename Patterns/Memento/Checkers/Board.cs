using System.Numerics;
using Patterns.Memento.Validation;
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

        public bool IsEmpty(Vector2Int position)
        {
            return _board[position.x, position.y] == 0;
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

        public BoardMemento Setup()
        {
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if ((x + y) % 2 != 0) continue;
                    _board[x, y] = 1;
                }
            }
            Console.Out.WriteLine(ToString());

            return CreateSnapshot();
        }

        public bool TryMakeMove(Vector2Int from, Vector2Int to, out BoardMemento? snapshot)
        {
            snapshot = null;

            if (ValidateMove(from, to))
            {
                _board[from.x, from.y] = 0;
                _board[to.x, to.y] = 1;

                snapshot = CreateSnapshot();
                return true;
            }

            return false;
        }

        private bool ValidateMove(Vector2Int from, Vector2Int to)
        {
            Vector2 direction = new Vector2(to.x - from.x, to.y - from.y);
            IsWithinBoardHandler withinBoardHandler = new IsWithinBoardHandler(this, from, to);
            withinBoardHandler
                .SetNext(new IsNotEmptyHandler(this, from, to))
                .SetNext(new DirectionValidationHandler(direction));

            return withinBoardHandler.Handle();
        }

        public override string ToString()
        {
            string result = String.Empty;
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                {
                    result += $"[ {_board[x, y]} ]";
                }
                result += "\n";
            }

            return result;
        }
    }
}