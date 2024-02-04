namespace ChessGame.Board;

public class MatchBoard
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    private Piece[,] Pieces { get; set; }

    public MatchBoard(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        Pieces = new Piece[rows, columns];
    }

    public Piece Piece(int linha, int coluna)
    {
        return Pieces[linha, coluna];
    }

    public Piece Piece(Position position)
    {
        return Pieces[position.Row, position.Column];
    }

    public bool PieceExists(Position position)
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

    public Piece TakePiece(Position position)
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
        if (position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
        {
            return false;
        }
        return true;
    }

    public void ValidatePosition(Position position)
    {
        if (!ValidPosition(position))
        {
            throw new BoardException("Invalid position!");
        }
    }
}