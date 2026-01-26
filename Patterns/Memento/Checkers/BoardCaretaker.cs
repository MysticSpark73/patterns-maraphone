namespace Patterns.Memento.Checkers
{
    public class BoardCaretaker
    {
        private Board _board;

        private Stack<BoardMemento> _stateLog = new ();

        public BoardCaretaker(Board board)
        {
            _board = board;
        }

        private void SetupBoard()
        {
            _board.Setup();
        }
    }
}