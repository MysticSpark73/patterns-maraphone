namespace Patterns.Memento.Checkers
{
    public class BoardMemento
    {
        public int Size { get; }
        public int[,] Board { get; }

        public BoardMemento(int size, int[,] board)
        {
            Size = size;
            Board = board;
        }
    }
}