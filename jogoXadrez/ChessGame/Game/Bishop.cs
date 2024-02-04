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

    public override bool CanMoveTo(Position pos)
    {
        Piece p = MatchBoard.Piece(pos);
        return p == null || p.Color != Color;
    }

    public override bool[,] PossibleMovements()
    {
        bool[,] matrix = new bool[MatchBoard.Rows, MatchBoard.Columns];

        Position pos = new Position(0, 0);

        // up-right
        pos.SetValues(MatchBoard.Rows - 1, MatchBoard.Columns + 1);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.SetValues(pos.Row - 1, pos.Column + 1);
        }

        // down-right
        pos.SetValues(MatchBoard.Rows + 1, MatchBoard.Columns + 1);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.SetValues(pos.Row + 1, pos.Column + 1);
        }

        // down-left
        pos.SetValues(MatchBoard.Rows + 1, MatchBoard.Columns - 1);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.SetValues(pos.Row + 1, pos.Column - 1);
        }

        // up-left
        pos.SetValues(MatchBoard.Rows - 1, MatchBoard.Columns - 1);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.SetValues(pos.Row - 1, pos.Column - 1);
        }

        return matrix;
    }
}