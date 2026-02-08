using Patterns.Memento.Vectors;

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

        public void SetupBoard()
        {
            _stateLog.Push( _board.Setup());
        }

        public void MakeMove(Vector2Int from, Vector2Int to)
        {
            if (_board.TryMakeMove(from, to, out var memento))
            {
                Console.Out.WriteLine($"Recorded move {from} -> {to}");
                Console.Out.WriteLine($"============================================");
                Console.Out.WriteLine(_board);
                Console.Out.WriteLine($"============================================");

                _stateLog.Push(memento);
            }
        }

        public void Undo()
        {
            if (_stateLog.Count <= 0) 
            {
                Console.Out.WriteLine("state log is empty!");
                return;
            }

            Console.Out.WriteLine("Undo last move");
            _stateLog.Pop();
            _board.RestoreState(_stateLog.Peek());
            Console.Out.WriteLine(_board);
        }
    }
}