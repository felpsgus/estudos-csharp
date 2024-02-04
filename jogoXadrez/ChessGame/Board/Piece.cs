namespace ChessGame.Board;

public abstract class Piece
{
    public Position Position { get; set; }
    public Color Color { get; protected set; }
    public int NumMovements { get; protected set; }
    public MatchBoard MatchBoard { get; protected set; }

    public Piece(MatchBoard matchBoard, Color color)
    {
        Position = null;
        MatchBoard = matchBoard;
        Color = color;
        NumMovements = 0;
    }

    public void IncreaseNumMovements()
    {
        NumMovements++;
    }

    public bool HasPossibleMovements()
    {
        bool[,] matrix = PossibleMovements();
        for (int i = 0; i < MatchBoard.Rows; i++)
        {
            for (int j = 0; j < MatchBoard.Columns; j++)
            {
                if (matrix[i, j])
                {
                    return true;
                }
            }
        }
        return false;
    }

    public abstract bool[,] PossibleMovements();

    public abstract bool CanMoveTo(Position pos);

}