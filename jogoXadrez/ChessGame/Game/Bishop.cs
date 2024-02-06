using ChessGame.Board;

namespace ChessGame.Game;

public class Bishop : Piece
{
    public Bishop(MatchBoard matchBoard, Color color) : base(matchBoard, color)
    {
    }

    public override string ToString()
    {
        return "B";
    }

    public override bool AllowedMovement(Position pos)
    {
        Piece p = MatchBoard.Piece(pos);
        return p == null || p.Color != Color;
    }

    public override bool[,] PossibleMovements()
    {
        bool[,] matrix = new bool[MatchBoard.Rows, MatchBoard.Columns];

        Position pos = new Position(0, 0);

        // up-right
        pos.SetValues(Position.Row - 1, Position.Column + 1);
        while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
            {
                break;
            }
            pos.SetValues(pos.Row - 1, pos.Column + 1);
        }

        // down-right
        pos.SetValues(Position.Row + 1, Position.Column + 1);
        while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
            {
                break;
            }
            pos.SetValues(pos.Row + 1, pos.Column + 1);
        }

        // down-left
        pos.SetValues(Position.Row + 1, Position.Column - 1);
        while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
            {
                break;
            }
            pos.SetValues(pos.Row + 1, pos.Column - 1);
        }

        // up-left
        pos.SetValues(Position.Row - 1, Position.Column - 1);
        while (MatchBoard.ValidPosition(pos) && AllowedMovement(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.Piece(pos) != null && MatchBoard.Piece(pos).Color != Color)
            {
                break;
            }
            pos.SetValues(pos.Row - 1, pos.Column - 1);
        }

        return matrix;
    }
}