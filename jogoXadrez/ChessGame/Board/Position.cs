namespace ChessGame.Board
{
    public class Position(int row, int column)
    {
        public int Row { get; set; } = row;
        public int Column { get; set; } = column;

        public void SetValues(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return $"{Row}, {Column}";
        }
    }
}