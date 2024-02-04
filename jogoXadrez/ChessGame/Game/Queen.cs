using ChessGame.Board;

namespace ChessGame.Game;

public class Queen : Piece
{
    public Queen(MatchBoard matchBoard, Color color) : base(matchBoard, color)
    {
    }

    public override string ToString()
    {
        return "Q";
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

        //up
        pos.SetValues(MatchBoard.Rows -1, Position.Column);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.Row = pos.Row - 1;
        }

        //up-right
        pos.SetValues(Position.Row - 1, Position.Column + 1);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.SetValues(pos.Row - 1, pos.Column + 1);
        }

        //right
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

        //down-right
        pos.SetValues(Position.Row + 1, Position.Column + 1);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.SetValues(pos.Row + 1, pos.Column + 1);
        }

        //down
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

        //down-left
        pos.SetValues(Position.Row + 1, Position.Column - 1);
        while (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
            if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
            {
                break;
            }
            pos.SetValues(pos.Row + 1, pos.Column - 1);
        }

        //left
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

        //up-left
        pos.SetValues(Position.Row - 1, Position.Column - 1);
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