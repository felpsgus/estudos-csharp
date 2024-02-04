using ChessGame.Board;

namespace ChessGame.Game;

public class King : Piece
{
    public King(MatchBoard matchBoard, Color color) : base(matchBoard, color)
    {
    }

    public override string ToString()
    {
        return "K";
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
        if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
        }

        //up-right
        pos.SetValues(Position.Row - 1, Position.Column + 1);
        if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
        }

        //right
        pos.SetValues(Position.Row, Position.Column + 1);
        if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
        }

        //down-right
        pos.SetValues(Position.Row + 1, Position.Column + 1);
        if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
        }

        //down
        pos.SetValues(Position.Row + 1, Position.Column);
        if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
        }

        //down-left
        pos.SetValues(Position.Row + 1, Position.Column - 1);
        if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
        }

        //left
        pos.SetValues(Position.Row, Position.Column - 1);
        if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
        }

        //up-left
        pos.SetValues(Position.Row - 1, Position.Column - 1);
        if (MatchBoard.ValidPosition(pos) && CanMoveTo(pos))
        {
            matrix[pos.Row, pos.Column] = true;
        }

        return matrix;
    }
}