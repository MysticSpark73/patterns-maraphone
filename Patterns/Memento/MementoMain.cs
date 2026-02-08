using Patterns.Common;
using Patterns.Memento.Checkers;
using Patterns.Memento.Vectors;

namespace Patterns.Memento
{
    public class MementoMain : IProgram
    {
        private const int CheckersBoardSize = 8;

        private BoardCaretaker _caretaker;
        
        public void Run(object[]? args = null)
        {
            CreateBoard();
            FillBoard();
            MakeMoves();
        }

        private void CreateBoard()
        {
            Board board = new Board(CheckersBoardSize);
            _caretaker = new BoardCaretaker(board);
        }

        private void FillBoard()
        {
            _caretaker.SetupBoard();
        }

        private void MakeMoves()
        {
            // _caretaker.MakeMove(new Vector2Int(), new Vector2Int());
            _caretaker.MakeMove(new Vector2Int(2, 0), new Vector2Int(3, 1));
            _caretaker.MakeMove(new Vector2Int(4, 2), new Vector2Int(5, 3));
            _caretaker.MakeMove(new Vector2Int(5, 3), new Vector2Int(4, 4));
            _caretaker.Undo();
        }
    }
}