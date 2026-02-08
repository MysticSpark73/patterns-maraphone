namespace Patterns.Memento.Checkers
{
    public class BoardMemento
    {
        public int Size { get; }
        public int[,] Board { get; }

        public BoardMemento(int size, int[,] board)
        {
            Size = size;
            Board = CloneBoardValues(size, board);
        }

        private int [,] CloneBoardValues(int size, int[,] board)
        {
            int [,] result = new int[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    result[x, y] = board[x, y];
                }
            }

            return result;
        }
    }
}