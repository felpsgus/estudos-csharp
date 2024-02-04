using ChessGame.Board;

namespace ChessGame.Game;

public class Tower : Piece
{
    public Tower(MatchBoard matchMatchBoard, Color color) : base(matchMatchBoard, color)
    {
    }

    public override string ToString()
    {
        return "T";
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

        // up
        pos.SetValues(Position.Row - 1, Position.Column);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.Row = pos.Row - 1;
        }

        // right
        pos.SetValues(Position.Row, Position.Column + 1);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.Column = pos.Column + 1;
        }

        // down
        pos.SetValues(Position.Row + 1, Position.Column);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.Row = pos.Row + 1;
        }

        // left
        pos.SetValues(Position.Row, Position.Column - 1);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.Column = pos.Column - 1;
        }


        return matrix;
    }
}