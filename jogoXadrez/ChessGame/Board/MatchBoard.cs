namespace ChessGame.Board
{
    public class MatchBoard(int rows, int columns)
    {
        public int Rows { get; set; } = rows;
        public int Columns { get; set; } = columns;
        private Piece[,] Pieces { get; set; } = new Piece[rows, columns];

        public Piece Piece(int row, int column)
        {
            return Pieces[row, column];
        }

        public Piece Piece(Position position)
        {
            return Pieces[position.Row, position.Column];
        }

        private bool PieceExists(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if (PieceExists(position))
            {
                throw new BoardException("There is already a piece in that position!");
            }
            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public Piece? TakePiece(Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }
            Piece aux = Piece(position);
            aux.Position = null;
            Pieces[position.Row, position.Column] = null;
            return aux;
        }

        public bool ValidPosition(Position position)
        {
            return position.Row >= 0 && position.Row < Rows && position.Column >= 0 && position.Column < Columns;
        }

        private void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}