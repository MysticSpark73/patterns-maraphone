using Patterns.Common;
using Patterns.Memento.Checkers;

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
            
        }

        private void MakeMoves()
        {
            
        }
    }
}