using ChessGame.Board;

namespace ChessGame.Game
{
    public class ChessPosition(char column, int row) : Position(row, column)
    {
        private char Column { get; set; } = column;
        private int Row { get; set; } = row;

        public Position ToPosition()
        {
            return new Position(8 - Row, Column - 'a');
        }

        public override string ToString()
        {
            return "" + Column + Row;
        }
    }
}